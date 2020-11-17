using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>SmsHandler</c> 
    /// A handler for sms messages
    /// </summary>
    public class SmsHandler : IHandler
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Processes an SMS message
        /// </summary>
        public void processMessage(Message message, IMessageMetrics messageMetrics, IList<Abbreviation> abbreviations)
        {
            //Split message text into array of strings by space
            string[] words = message.MessageText.Split(' ');

            //Set sender to first word in array
            message.MessageSender = words[0];

            //Save the processed text in string
            string processedText = "";

            //Loop through all the words starting, on the 2nd word
            for(int x=1; x<words.Length; x++)
            {
                //Check if current word is an abbreviation and return the correct abbreviation object if it does
                var abbreviation = abbreviations.FirstOrDefault(abbreviation => abbreviation.Abbrv == words[x]);

                //If it is an abbreviation then update the current word to contain the abbreviation translation
                if (abbreviation != null)
                {
                    processedText += String.Format("{0}<{1}> ", words[x], abbreviation.Translation);
                }
                else
                {
                    processedText += words[x] + " ";
                }
            }

            //Trim end space off
            message.MessageText = processedText.Trim();
        }
    }
}
