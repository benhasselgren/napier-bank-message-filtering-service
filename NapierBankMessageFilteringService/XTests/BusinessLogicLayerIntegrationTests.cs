using Autofac;
using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using XTests.TestClasses;
using Xunit;

namespace XTests
{
    public  class BusinessLogicLayerIntegrationTests
    {
        [Fact]
        public void testSMSProcessMessageCorrectOutput()
        {
            string header = "S1234567701";
            string body = "+447911123456 The most important LOL to remember is to add the international LTM code.";

            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            //Process message
            SmsMessage m = (SmsMessage)mbf.processMessage(header, body);

            MessageType expectedType = MessageType.SMS;
            string expectedId = "S1234567701";
            string expectedSender = "+447911123456";
            string expectedText = "The most important LOL<Laughing out loud> to remember is to add the international LTM<Laugh to myself> code.";

            Assert.Equal(expectedType, m.MessageType);
            Assert.Equal(expectedId, m.MessageId);
            Assert.Equal(expectedSender, m.MessageSender);
            Assert.Equal(expectedText, m.MessageText);
        }

        [Fact]
        public void testSEEmailProcessMessageCorrectOutput()
        {
            string header = "E1294567704";
            string body = "test@gmail.com The most important B dog http:\\\\www.anywhere.com. Further detail of email messages is provided in 3.1.2 below.";

            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            //Process message
            EmailMessage m = (EmailMessage)mbf.processMessage(header, body);

            MessageType expectedType = MessageType.Email;
            string expectedId = "E1294567704";
            string expectedSender = "test@gmail.com";
            string expectedSubject = "The most important B";
            string expectedText = "dog <URL Quarantined> Further detail of email messages is provided in 3.1.2 below.";
            Assert.Equal(expectedType, m.MessageType);
            Assert.Equal(expectedId, m.MessageId);
            Assert.Equal(expectedSender, m.MessageSender);
            Assert.Equal(expectedSubject, m.MessageSubject);
            Assert.Equal(expectedText, m.MessageText);
        }

        [Fact]
        public void testSIREmailProcessMessageCorrectOutput()
        {
            string header = "E1294567704";
            string body = "test@gmail.com SIR 07/11/98\r\nSort Code: 99-99-99\r\nNature of Incident: Theft\r\nThe most important B4N to remember is to add the #dog ADN code. A mobile LOL number in the United Kingdom always starts. contain embedded hyperlinks in the form of standard URLs e.g. http:\\\\www.anywhere.com. Further detail of email messages is provided in 3.1.2 below.";

            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            //Process message
            EmailMessage m = (EmailMessage)mbf.processMessage(header, body);

            MessageType expectedType = MessageType.Email;
            string expectedId = "E1294567704";
            string expectedSender = "test@gmail.com";
            string expectedSubject = "SIR 07/11/98";
            string expectedText = "Sort Code: 99-99-99\rNature of Incident: Theft\rThe most important B4N to remember is to add the #dog ADN code. A mobile LOL number in the United Kingdom always starts. contain embedded hyperlinks in the form of standard URLs e.g. <URL Quarantined> Further detail of email messages is provided in 3.1.2 below.";

            Assert.Equal(expectedType, m.MessageType);
            Assert.Equal(expectedId, m.MessageId);
            Assert.Equal(expectedSender, m.MessageSender);
            Assert.Equal(expectedSubject, m.MessageSubject);
            Assert.Equal(expectedText, m.MessageText);
        }

        [Fact]
        public void testTweetProcessMessageCorrectOutput()
        {
            string header = "T1294567701";
            string body = "@Ben The most important LTM to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL";

            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            //Process message
            TweetMessage m = (TweetMessage)mbf.processMessage(header, body);

            MessageType expectedType = MessageType.Tweet;
            string expectedId = "T1294567701";
            string expectedSender = "@Ben";
            string expectedText = "The most important LTM<Laugh to myself> to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL<Laughing out loud>";

            Assert.Equal(expectedType, m.MessageType);
            Assert.Equal(expectedId, m.MessageId);
            Assert.Equal(expectedSender, m.MessageSender);
            Assert.Equal(expectedText, m.MessageText);
        }

        [Fact]
        public void testProcessMessageWithEmptyString()
        {
            string header = "";
            string body = "";

            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            try
            {
                //Process message
                TweetMessage m = (TweetMessage)mbf.processMessage(header, body);
            }
            catch(Exception ex)
            {
                string expectedMessage = "Missing text or header";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testProcessMessagesByFile()
        {
            //Set up facade class with injection
            var container = TestContainerConfig.Configure("DATAFACADE");

            var mbf = container.Resolve<IMessageBankFacade>();

            string path = "../../../Data/test.csv";

            mbf.processMessagesByFile(path);

            Assert.Equal(3, mbf.getMessageMetrics().getMentions().Count);
        }

        [Fact]
        public void testProcessMessagesWithNoFile()
        {
            //Set up facade class with injection
            var container = TestContainerConfig.Configure("DATAFACADE");

            var mbf = container.Resolve<IMessageBankFacade>();

            string path = "";

            try
            {
                //Process message
                mbf.processMessagesByFile(path);
            }
            catch (Exception ex)
            {
                string expectedMessage = "You need to provide a file to read from";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testSaveMessagesWithNoFile()
        {
            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            string path = "";

            try
            {
                //Process message
                mbf.saveMessages(path);
            }
            catch (Exception ex)
            {
                string expectedMessage = "You need to provide a file to save to";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testVerifyMessageNullMessage()
        {
            //Set up facade class with injection
            var container = TestContainerConfig.Configure();

            var mbf = container.Resolve<IMessageBankFacade>();

            try
            {
                mbf.verifyMessage(null);
            }
            catch (Exception ex)
            {
                string expectedMessage = "Message is empty";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }
    }
}
