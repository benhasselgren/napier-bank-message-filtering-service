using DataLayer;
using Models;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Interface <c>IMessageBankFacade</c> 
    /// An interface for MessageBankFacade
    /// </summary>
    public interface IMessageBankFacade
    {
        public Message processMessage(string header, string body);
        public bool processMessagesByFile(string file);
        public bool saveMessages(string filepath);
        public bool verifyMessage(Message message);
        public IMessageMetrics getMessageMetrics();
    }
}