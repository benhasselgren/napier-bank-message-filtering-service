using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Classes
{
    /// <summary>
    /// Class <c>DataFacade</c> 
    /// A facade that the business layer can communicate with to create, load and save messages
    /// </summary>
    public class DataFacade
    {
        // ------------------ Instance Variables ------------------
        private FileSingleton file;
        private MessageFactory messageFactory;
        private List<Message> unprocessedMessages;

        // ------------------ Constructors ------------------

        // ------------------ Getters/Setters ------------------
        internal FileSingleton File { get => file; set => file = value; }
        internal MessageFactory MessageFactory { get => messageFactory; set => messageFactory = value; }
        internal List<Message> UnprocessedMessages { get => unprocessedMessages; set => unprocessedMessages = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>loadMessages</c> 
        /// Loads messages from a file
        /// </summary>
        private void loadMessages(string file)
        {

        }

        /// <summary>
        /// Method <c>createMessage</c> 
        /// Creates a message from user input
        /// </summary>
        private void createMessage(string body, string header)
        {

        }

        /// <summary>
        /// Method <c>saveMessage</c> 
        /// Saves processed messaged to a json file
        /// </summary>
        private void saveMessage(List<Message> processedMessages)
        {

        }
    }
}
