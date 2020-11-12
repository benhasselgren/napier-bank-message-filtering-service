using DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Classes
{
    /// <summary>
    /// Class <c>ProcessedMessageFactory</c> 
    /// A factory class used to instantiate Processed Message objects and return a list of processed Messages.
    /// Can create sms, email and tweet messages
    /// </summary>
    class ProcessedMessageFactory
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>createSmsMessage</c> 
        /// Returns a sms message
        /// </summary>
        public SmsMessage createSmsMessage(Message message)
        {
            return null;
        }

        /// <summary>
        /// Method <c>createEmailMessage</c> 
        /// Returns an email message
        /// </summary>
        public SmsMessage createEmailMessage(Message message)
        {
            return null;
        }

        /// <summary>
        /// Method <c>createTweetMessage</c> 
        /// Returns a tweet message
        /// </summary>
        public SmsMessage createTweetMessage(Message message)
        {
            return null;
        }
    }
}
