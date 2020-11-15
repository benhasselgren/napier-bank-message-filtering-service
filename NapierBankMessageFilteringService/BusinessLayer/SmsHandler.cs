using Models;
using System;
using System.Collections.Generic;
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
        public void processMessage(Message message, IMessageMetrics messageMetrics, List<Abbreviation> abbreviations)
        {
            //Split message text into array of strings by space
            string[] words = message.MessageText.Split(' ');

            //Set sender to first word in array
            message.MessageSender = words[0];

            //Loop through all the words starting, on the 2nd word
            for(int x=1; x<words.Length; x++)
            {
                if(messageMetrics.M.Any(s => myString.Contains(s));])
            }
        }
    }
}
