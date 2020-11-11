using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Classes
{
    /// <summary>
    /// Class <c>Message</c> 
    /// A class that stores unprocessed and processed messages.
    /// </summary>
    public class Message
    {
        // ------------------ Instance Variables ------------------
        private string messageType;
        private string header;
        private string body;

        // ------------------ Constructors ------------------
        /// <summary>
        /// Constructor <c>messageType, body, header</c> 
        /// A constrcutor that takes 3 inputs.
        /// Calls getMessageType() to find message type
        /// </summary>
        public Message(string messageType, string body, string header)
        {
            this.MessageType = getMessageType(header);
            this.Body = body;
            this.Header = header;
        }

        // ------------------ Getters/Setters ------------------
        public string MessageType { get => messageType; set => messageType = value; }
        public string Header { get => header; set => header = value; }
        public string Body { get => body; set => body = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>getMessageType</c> 
        /// Finds what type a message is by checking the 1st letter of the header string
        /// </summary>
        private string getMessageType(string header)
        {
            string messageType = "";

            if (header.Trim().StartsWith("S"))
            {
                messageType = "SMS";
            }
            else if(header.Trim().StartsWith("E"))
            {
                messageType = "EMAIL";
            }
            else
            {
                messageType = "TWEET";
            }

            return messageType;
        }
    }
}
