using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>MessageBankFacade</c> 
    /// A facade that the presentation layer can communicate with to process messages
    /// </summary>
    public class MessageBankFacade : IMessageBankFacade
    {

        // ------------------ Instance Variables ------------------
        public IList<Abbreviation> Abbreviations { get; set; }
        public IList<Message> ProcessedMessages { get; set; }
        public IMessageMetrics MessageMetrics { get; set; }
        public IDataFacade MessageData { get; set; }
        public IMessageFactory MessageFactory { get; set; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessagesByFile</c> 
        /// Loads messages from a file by calling loadData() in data layer
        /// </summary>
        public bool processMessagesByFile(string file)
        {
            return false;
        }

        /// <summary>
        /// Method <c>processMessage</c> 
        /// Adds a new message and processes it
        /// </summary>
        public Message processMessage(string header, string body)
        {
            return null;
        }

        /// <summary>
        /// Method <c>verifyMessage</c> 
        /// Verify a processed message and adds it to the processed message list
        /// </summary>
        public bool verifyMessage(Message message)
        {
            return false;
        }

        /// <summary>
        /// Method <c>saveMessages</c> 
        /// Saves messages to file
        /// </summary>
        public bool saveMessages()
        {
            return false;
        }
    }
}
