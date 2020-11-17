using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Interface <c>IMessageFactory</c> 
    /// An interface for MessageFactory
    /// </summary>
    public interface IMessageFactory
    {
        public Message createMessage(string header, string body);
        public IHandler getHandler(Message message);
    }
}