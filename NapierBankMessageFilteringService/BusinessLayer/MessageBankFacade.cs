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
        public IList<Abbreviation> Abbreviations { get; private set; }
        public IList<Message> ProcessedMessages { get; private set; }
        public IMessageMetrics MessageMetrics { get; private set; }
        public IDataFacade MessageData { get; private set; }
        public IMessageFactory MessageFactory { get; private set; }

        // ------------------ Constructor ------------------
        public MessageBankFacade(IMessageMetrics messageMetrics, IDataFacade messageData, IMessageFactory messageFactory)
        {
            Abbreviations = new List<Abbreviation>();
            ProcessedMessages = new List<Message>();
            MessageMetrics = messageMetrics;
            MessageData = messageData;
            MessageFactory = messageFactory;
        }

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
            //Create a message
            Message message = MessageFactory.createMessage(header, body);

            //Get the correct handler to process the message
            IHandler handler = MessageFactory.getHandler(message);

            //Process the message
            handler.processMessage(message, MessageMetrics, Abbreviations);

            return message;
        }

        /// <summary>
        /// Method <c>verifyMessage</c> 
        /// Verify a processed message and adds it to the processed message list
        /// </summary>
        public bool verifyMessage(Message message)
        {
            ProcessedMessages.Add(message);
            return true;
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
