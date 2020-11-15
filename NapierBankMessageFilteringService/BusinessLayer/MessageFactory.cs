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
        public Message createMessage(string header, string body, IMessageMetrics messageMetrics)
        {
            Message message;

            if(header.StartsWith("S"))
            {
                //Create new message
                message = new SmsMessage();
                //Set message type
                message.MessageType = "SMS";
                //Set messageId to header
                message.MessageId = header;
            }
            else if (header.StartsWith("E"))
            {
                //Create new message
                message = new SmsMessage();
                //Set message type
                message.MessageType = "EMAIL";
                //Set messageId to header
                message.MessageId = header;
            }
            else if (header.StartsWith("T"))
            {
                //Create new message
                message = new SmsMessage();
                //Set message type
                message.MessageType = "TWEET";
                //Set messageId to header
                message.MessageId = header;
            }
            else
            {
                throw new Exception(String.Format("ERROR: Header starts with: '{0}', Must start with S, E or T", header[0]));
            }

            //Get the correct handler to process the message
            IHandler handler = getHandler(message);

            //Process the message
            handler.processMessage(message, messageMetrics);

            //Return the message
            return message;
        }

        /// <summary>
        /// Method <c>getHandler</c> 
        /// Returns the correct handler depending on the message type
        /// </summary>
        public IHandler getHandler(Message message)
        {
            if (message.MessageType.Equals("SMS"))
            {
                //Return sms handler if sms
                SmsHandler handler = new SmsHandler();
                return handler;
            }
            else if (message.MessageType.Equals("EMAIL"))
            {
                //Return email handler if email
                EmailHandler handler = new EmailHandler();
                return handler;
            }
            else
            {
                //Return tweet handler if tweet
                TweetHandler handler = new TweetHandler();
                return handler;
            }
        }
    }
}
