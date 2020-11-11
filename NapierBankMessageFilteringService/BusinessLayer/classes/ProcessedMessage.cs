using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.classes
{
    /// <summary>
    /// Abstract Class <c>ProcessedMessage</c> 
    /// An abstract class that stores the fundamental design of all processed messages
    /// </summary>
    abstract class ProcessedMessage
    {

        // ------------------ Instance Variables ------------------
        private string messageType;
        private string messageId;
        private string messageSender;
        private string messageText;

        // ------------------ Constructors ------------------

        // ------------------ Getters/Setters ------------------
        public string MessageType { get => messageType; set => messageType = value; }
        public string MessageId { get => messageId; set => messageId = value; }
        public string MessageSender { get => messageSender; set => messageSender = value; }
        public string MessageText { get => messageText; set => messageText = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Abstract Method <c>processMessage</c> 
        /// Allows classes that implement this method to have unique processing formats
        /// </summary>
        public abstract void processMessage(string header, string body);


    }
}
