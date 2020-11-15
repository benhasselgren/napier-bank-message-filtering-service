using Models;

namespace BusinessLayer
{
    /// <summary>
    /// Interface <c>IMessageFactory</c> 
    /// An interface for MessageFactory
    /// </summary>
    public interface IMessageFactory
    {
        public Message createMessage(string header, string body, IMessageMetrics messageMetrics);
        public IHandler getHandler(Message message);
    }
}