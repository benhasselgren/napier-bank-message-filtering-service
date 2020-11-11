using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.classes
{
    /// <summary>
    /// Class <c>SmsMessage</c> 
    /// Inherits from ProcessedMessage 
    /// Outlines an SMS message
    /// </summary>
    class SmsMessage : ProcessedMessage
    {
        // ------------------ Instance Variables ------------------

        // ------------------ Constructors ------------------

        // ------------------ Getters/Setters ------------------

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Used to create an sms message by processing input
        /// </summary>
        public override void processMessage(string header, string body)
        {

        }

        /// <summary>
        /// Method <c>ToString</c> 
        /// Returns a string of variables in class
        /// </summary>
        public override string ToString()
        {
            string output = String.Format("Sms Message: {0}, {1}, {2}, {3}", this.MessageType, this.MessageId, this.MessageSender, this.MessageText);
            return output;
        }
    }
}
