using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Classes
{
    /// <summary>
    /// Class <c>MessageFactory</c> 
    /// A factory class used to instantiate Message objects and return a list of Messages.
    /// Can create a message from user input
    /// Can create messages from reading a file
    /// </summary>
    class MessageFactory
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>readFileMessages</c> 
        /// Returns a list of messages from reading a file
        /// </summary>
        public List<Message> readFileMessages(string file)
        {
            return null;
        }

        /// <summary>
        /// Method <c>createMessage</c> 
        /// Returns a list of messages from a users input
        /// </summary>
        public List<Message> createMessage(string header, string body)
        {
            return null;
        }

    }
}
