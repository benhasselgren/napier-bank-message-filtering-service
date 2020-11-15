using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public enum MessageType
    {
        SMS,
        Tweet,
        Email
    }
    /// <summary>
    /// Abstract Class <c>ProcessedMessage</c> 
    /// An abstract class that stores the fundamental design of all processed messages
    /// </summary>
    public class Message
    {
        // ------------------ Properties ------------------
        public MessageType MessageType { get; set; }
        public string MessageId { get; set; }
        public string MessageSender { get; set; }
        public string MessageText { get; set; }
    }
}
