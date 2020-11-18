using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>TweetHandler</c> 
    /// A handler for tweet messages
    /// </summary>
    public class TweetHandler : IHandler
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Processes an tweet message
        /// </summary>
        public void processMessage(Message message, IMessageMetrics messageMetrics, IList<Abbreviation> abbreviations)
        {
            //Split message text into array of strings by space
            string[] words = message.MessageText.Split(' ');

            if (words[0].Length > 16)
            {
                throw new Exception("Character limit is 140 characters for tweet username");
            }

            //Set sender to first word in array
            message.MessageSender = words[0];

            //Save the processed text in string
            string processedText = "";

            //Loop through all the words starting, on the 2nd word
            for (int x = 1; x < words.Length; x++)
            {
                //Check if current word is an abbreviation and return the correct abbreviation object if it does
                var abbreviation = abbreviations.FirstOrDefault(abbreviation => abbreviation.Abbrv == words[x]);

                if (abbreviation != null)
                {
                    //If it is an abbreviation then update the current word to contain the abbreviation translation
                    processedText += String.Format("{0}<{1}> ", words[x], abbreviation.Translation);
                }
                else if (words[x].StartsWith("@"))
                {
                    //If it is a mention then add the word to mentions list
                    messageMetrics.addMention(words[x]);

                    //Add space after word
                    processedText += words[x] + " ";
                }
                else if (words[x].StartsWith("#"))
                {
                    //If it is a hashtag then add the word to hashtag list
                    messageMetrics.addHashtag(words[x]);

                    //Add space after word
                    processedText += words[x] + " ";
                }
                else
                {
                    //Add space after word
                    processedText += words[x] + " ";
                }
            }

            //Trim end space off
            message.MessageText = processedText.Trim();

            if (processedText.Length > 140)
            {
                throw new Exception("Character limit is 140 characters for tweet text");
            }
        }
    }
}
