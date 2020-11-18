using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Interface <c>IHandler</c> 
    /// An interface for handlers
    /// </summary>
    public interface IHandler
    {
        public void processMessage(Message message, IMessageMetrics messageMetrics, IList<Abbreviation> abbreviations);
    }
}
