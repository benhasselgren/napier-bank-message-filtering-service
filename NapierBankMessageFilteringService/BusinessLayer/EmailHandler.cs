using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>EmailHandler</c> 
    /// A handler for email messages
    /// </summary>
    public class EmailHandler : IHandler
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Processes an email message
        /// </summary>
        public void processMessage(Message message, IMessageMetrics messageMetrics, IList<Abbreviation> abbreviations)
        {
            //Cast type to email messages
            EmailMessage emailMessage = (EmailMessage)message;

            var spaceIndex = emailMessage.MessageText.IndexOf(' ');
            
            //If no space after email throw error
            if (spaceIndex < 0) throw new Exception("Bad format");

            //Set email to first word in string 
            var email = emailMessage.MessageText.Substring(0, spaceIndex);
            emailMessage.MessageSender = email;

            //Save the processed text in string
            string processedText = "";

            //Set the subject of email message
            var subject = emailMessage.MessageText.Substring(spaceIndex + 1, 12);

            string pattern = @"SIR \d\d\/\d\d\/\d\d.*";
            Match m = Regex.Match(subject, pattern);

            if (m.Success)
            {
                //If email is sir email then process accordingly
                emailMessage.MessageSubject = subject;

                //Set rest of words to body
                var body = emailMessage.MessageText.Substring(spaceIndex + 14);

                //Remove extra backslash
                string[] sirBody = body.Split("\r\n", StringSplitOptions.None);

                //Get sortcode and nature of incident and add them to message metrics
                var matchSortCode = Regex.Match(sirBody[0], "(?<=:).*");
                var matchNoi = Regex.Match(sirBody[1], "(?<=:).*");
                messageMetrics.addSir(matchSortCode.Value.Trim(), matchNoi.Value.Trim());

                processedText += sirBody[0] + "\r" + sirBody[1] + "\r";

                //Split rest of text by spaces
                string[] words = sirBody[2].Split(' ');

                foreach (string word in words)
                {
                    pattern = @"http.?:\\\\www.*";
                    m = Regex.Match(word, pattern);

                    if (m.Success)
                    {
                        //If it is a url then add url to quarantine list and replace with url quarantined
                        processedText += "<URL Quarantined> ";
                        messageMetrics.addUrl(word);
                    }
                    else
                    {
                        //Add space after word
                        processedText += word + " ";
                    }
                }
            }
            else
            {
                //If email is se email then process accordingly
                //Set the subject of email message
                var seSubject = emailMessage.MessageText.Substring(spaceIndex + 1, 20);
                emailMessage.MessageSubject = seSubject;

                //Set rest of words to body
                var body = emailMessage.MessageText.Substring(spaceIndex + 21);

                //Split body into words
                string[] words = body.Split(' ');
 
                foreach(string word in words)
                {
                    pattern = @"http.?:\\\\www.*";
                    m = Regex.Match(word, pattern);

                    if (m.Success)
                    {
                        //If it is a url then add url to quarantine list and replace with url quarantined
                        processedText += "<URL Quarantined> ";
                        messageMetrics.addUrl(word);
                    }
                    else
                    {
                        //Add space after word
                        processedText += word + " ";
                    }
                }
            }

            //Trim end space off
            emailMessage.MessageText = processedText.Trim();

            if (processedText.Length > 1028)
            {
                throw new Exception("Character limit is 1028 characters for email text");
            }
        }
    }
}
