using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    /// <summary>
    /// Class <c>SmsHandler</c> 
    /// A handler for sms messages
    /// </summary>
    public class SmsHandler : IHandler
    {
        // ------------------ Methods ------------------
        /// <summary>
        /// Method <c>processMessage</c> 
        /// Processes an SMS message
        /// </summary>
        public void processMessage(Message message, IMessageMetrics messageMetrics)
        {
            throw new NotImplementedException();
        }
    }
}
