using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    /// <summary>
    /// Abstract Class <c>ProcessedMessage</c> 
    /// An abstract class that stores the fundamental design of all processed messages
    /// </summary>
    public class Message
    {
        // ------------------ Properties ------------------
        public string MessageType { get; set; }
        public string MessageId { get; set; }
        public string MessageSender { get; set; }
        public string MessageText { get; set; }
    }
}
