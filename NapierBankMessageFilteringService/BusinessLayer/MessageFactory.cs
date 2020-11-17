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
            Message message;

            if(header.StartsWith("S"))
            {
                //Create new message
                message = new SmsMessage();
                //Set message type
                message.MessageType = MessageType.SMS;
                //Set messageId to header
                message.MessageId = header;
                //Set messageTExt to body
                message.MessageText = body;
            }
            else if (header.StartsWith("E"))
            {
                //Create new message
                message = new EmailMessage();
                //Set message type
                message.MessageType = MessageType.Email;
                //Set messageId to header
                message.MessageId = header;
                //Set messageTExt to body
                message.MessageText = body;
            }
            else if (header.StartsWith("T"))
            {
                //Create new message
                message = new TweetMessage();
                //Set message type
                message.MessageType = MessageType.Tweet;
                //Set messageId to header
                message.MessageId = header;
                //Set messageTExt to body
                message.MessageText = body;
            }
            else
            {
                throw new Exception(String.Format("ERROR: Header starts with: '{0}', Must start with S, E or T", header[0]));
            }

            //Return the message
            return message;
        }

        /// <summary>
        /// Method <c>getHandler</c> 
        /// Returns the correct handler depending on the message type else throws a message
        /// </summary>
        public IHandler getHandler(Message message)
        {
            switch (message.MessageType)
            {
                case MessageType.SMS:
                    //Return sms handler if sms
                    return new SmsHandler();
                case MessageType.Email:
                    return new EmailHandler();
                case MessageType.Tweet:
                    return new TweetHandler();
                default:
                    throw new Exception("ERROR: Message type is wrong, check your header input");
            }
        }
    }
}
