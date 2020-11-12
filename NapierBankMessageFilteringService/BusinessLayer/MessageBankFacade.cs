using BusinessLayer.Classes;
using DataLayer.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>MessageBankFacade</c> 
    /// A facade that the presentation layer can communicate with to process messages
    /// </summary>
    public class MessageBankFacade
    {

        public static class abbreviations 
        {
            public const string rofl = "rofl";
        }

        // ------------------ Instance Variables ------------------
        private List<Hashtag> trendingList = new List<Hashtag>();
        private List<string> mentions = new List<string>();
        private List<string> sirList = new List<string>();
        private List<ProcessedMessage> processedMessages = new List<ProcessedMessage>();
        private DataFacade messageData = new DataFacade();
        private ProcessedMessageFactory processedMessageFactory = new ProcessedMessageFactory();
        //private Abbreviations abbreviations = new Abbreviations();

        // ------------------ Constructors ------------------

        // ------------------ Getters/Setters ------------------
        internal List<Hashtag> TrendingList { get => trendingList; set => trendingList = value; }
        public List<string> Mentions { get => mentions; set => mentions = value; }
        public List<string> SirList { get => sirList; set => sirList = value; }
        internal List<ProcessedMessage> ProcessedMessages { get => processedMessages; set => processedMessages = value; }
        public DataFacade MessageData { get => messageData; set => messageData = value; }
        internal ProcessedMessageFactory ProcessedMessageFactory { get => processedMessageFactory; set => processedMessageFactory = value; }

        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>loadMessagesByFile</c> 
        /// Loads messages from a file by calling loadMessages() in data layer
        /// </summary>
        public bool loadMessagesByFile(string file)
        {
            return false;
        }

        /// <summary>
        /// Method <c>addMessage</c> 
        /// Adds a new message and processes it
        /// </summary>
        public ProcessedMessage addMessage(string header, string body)
        {
            return null;
        }

        /// <summary>
        /// Method <c>verifyMessage</c> 
        /// Verify a processed message and adds it to the processed message list
        /// </summary>
        public ProcessedMessage verifyMessage(ProcessedMessage unverifiedMessage)
        {
            return null;
        }

        /// <summary>
        /// Method <c>saveMessage</c> 
        /// Savesa messages to file
        /// </summary>
        public bool saveData()
        {
            return false;
        }
    }
}
