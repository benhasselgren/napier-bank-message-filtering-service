using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Classes
{
    /// <summary>
    /// Class <c>DataFacade</c> 
    /// A facade that the business layer can communicate with to create, load and save messages
    /// </summary>
    public class DataFacade : IDataFacade
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>loadMessages</c> 
        /// Loads messages from a file
        /// </summary>
        public void loadData(string file)
        {

        }

        /// <summary>
        /// Method <c>createMessage</c> 
        /// Creates a message from user input
        /// </summary>
        public void saveData(List<Message> processedMessages)
        {

        }

        /// <summary>
        /// Method <c>saveMessage</c> 
        /// Saves processed messaged to a json file
        /// </summary>
        public void loadAbbreviations(List<Abbreviation> abbreviations)
        {

        }
    }
}
