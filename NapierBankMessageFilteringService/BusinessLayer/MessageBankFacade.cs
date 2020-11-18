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
        public IMessageMetrics TemporaryMessageMetrics { get; private set; }
        public IDataFacade MessageData { get; private set; }
        public IMessageFactory MessageFactory { get; private set; }

        // ------------------ Constructor ------------------
        public MessageBankFacade(IMessageMetrics messageMetrics, IMessageMetrics singleMessageMetrics, IDataFacade messageData, IMessageFactory messageFactory)
        {
            Abbreviations = new List<Abbreviation>();
            ProcessedMessages = new List<Message>();
            MessageMetrics = messageMetrics;
            MessageData = messageData;
            MessageFactory = messageFactory;
            TemporaryMessageMetrics = singleMessageMetrics;

            //Populate abbreviations list
            messageData.loadAbbreviations(Abbreviations);
        }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessagesByFile</c> 
        /// Loads messages from a file by calling loadData() in data layer
        /// </summary>
        public bool processMessagesByFile(string file)
        {
            if (!file.Equals(""))
            {
                List<string> data = MessageData.loadData(file);

                foreach (string line in data)
                {
                    string[] fields = line.Split(",,");
                    verifyMessage(processMessage(fields[0], fields[1]));
                }
                return true;
            }
            else
            {
                throw new Exception("You need to provide a file to read from");
            }
        }

        /// <summary>
        /// Method <c>processMessage</c> 
        /// Adds a new message and processes it
        /// </summary>
        public Message processMessage(string header, string body)
        {
            if(!header.Equals("") || !body.Equals(""))
            {
                //Create a message
                Message message = MessageFactory.createMessage(header, body);

                //Get the correct handler to process the message
                IHandler handler = MessageFactory.getHandler(message);

                TemporaryMessageMetrics.reset();

                //Process the message
                handler.processMessage(message, TemporaryMessageMetrics, Abbreviations);

                return message;
            }
            else
            {
                throw new Exception("Missing text or header");
            }
        }

        /// <summary>
        /// Method <c>verifyMessage</c> 
        /// Verify a processed message and adds it to the processed message list
        /// </summary>
        public bool verifyMessage(Message message)
        {
            if(message != null)
            {
                MessageMetrics.addMetrics(TemporaryMessageMetrics);
                ProcessedMessages.Add(message);
                return true;
            }
            else
            {
                throw new Exception("Message is empty");
            }
            
        }

        /// <summary>
        /// Method <c>saveMessages</c> 
        /// Saves messages to file
        /// </summary>
        public bool saveMessages(string filepath)
        {
            if (!filepath.Equals(""))
            {
                MessageData.saveData(ProcessedMessages, filepath);
                return true;
            }
            else
            {
                throw new Exception("You need to provide a file to save to");
            }
        }

        /// <summary>
        /// Method <c>getMessageMetrics</c> 
        /// Returns the message metrics
        /// </summary>
        public IMessageMetrics getMessageMetrics()
        {
            return MessageMetrics;
        }
    }
}
