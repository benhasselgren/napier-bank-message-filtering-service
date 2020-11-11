using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.classes
{
    /// <summary>
    /// Class <c>EmailMessage</c> 
    /// Inherits from ProcessedMessage 
    /// Outlines an Email message
    /// </summary>
    class EmailMessage : ProcessedMessage
    {
        // ------------------ Instance Variables ------------------
        private string messageSubject;
        private string sortCode;
        private string natureOfIncident;

        // ------------------ Constructors ------------------

        // ------------------ Getters/Setters ------------------
        public string MessageSubject { get => messageSubject; set => messageSubject = value; }
        public string SortCode { get => sortCode; set => sortCode = value; }
        public string NatureOfIncident { get => natureOfIncident; set => natureOfIncident = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Used to create an email message by processing input
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
            string output = String.Format("Sms Message: {0}, {1}, {2}, {3}, {4}, {5}, {6}", this.MessageType, 
                this.MessageId, 
                this.MessageSender, 
                this.MessageText,
                this.MessageSubject,
                this.SortCode,
                this.NatureOfIncident);
            return output;
        }
    }
}
