using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>ProcessedMessageFactory</c> 
    /// A factory class used to instantiate a Message
    /// </summary>
    public class MessageFactory : IMessageFactory
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>createMessage</c> 
        /// Returns a Message
        /// </summary>
        public Message createMessage(string header, string body)
        {
            return null;
        }

        /// <summary>
        /// Method <c>getHandler</c> 
        /// Returns the correct handler depending on the message type
        /// </summary>
        public IHandler getHandler(Message message)
        {
            return null;
        }
    }
}
