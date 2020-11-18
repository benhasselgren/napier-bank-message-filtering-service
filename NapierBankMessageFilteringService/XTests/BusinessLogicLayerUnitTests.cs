using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using XTests.TestClasses;
using Xunit;

namespace XTests
{
    public class BusinessLogicLayerUnitTests
    {
        [Fact]
        public void testSMSProcessMessageCorrectOutput()
        {
            //Create new message and message metrics
            SmsMessage message = new SmsMessage();
            message.MessageType = MessageType.SMS;
            //Set messageId to header
            message.MessageId = "S1234567701";
            //Set messageTExt to body
            message.MessageText = "+447911123456 The most important LOL to remember is to add the international LTM code.";
            MessageMetrics metrics = new MessageMetrics();

            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new sms handler
            SmsHandler handler = new SmsHandler();

            //Process message
            handler.processMessage(message, metrics, abbreviations);

            string expectedSender = "+447911123456";
            string expectedText = "The most important LOL<Laughing out loud> to remember is to add the international LTM<Laugh to myself> code.";

            Assert.Equal(expectedSender, message.MessageSender);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testSMSProcessMessageCorrectOutputMaxText()
        {
            //Create new message and message metrics
            SmsMessage message = new SmsMessage();
            message.MessageType = MessageType.SMS;
            //Set messageId to header
            message.MessageId = "S1234567701";
            //Set messageTExt to body
            message.MessageText = "+447911123456 The most important LOL to remember is to add the international LTM code. A mobile LYLAS number in the United Kingdom always starts and this i";
            MessageMetrics metrics = new MessageMetrics();

            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new sms handler
            SmsHandler handler = new SmsHandler();

            try
            {
                //Process message
                handler.processMessage(message, metrics, abbreviations);
            }
            catch(Exception ex)
            {
                string expectedMessage = "Character limit is 140 characters for sms text";
                Assert.Equal(expectedMessage, ex.Message);
            }  
        }

        [Fact]
        public void testSEEmailProcessMessageCorrectOutput()
        {
            //Create new message and message metrics
            EmailMessage message = new EmailMessage();
            message.MessageType = MessageType.Email;
            //Set messageId to header
            message.MessageId = "E1294567704";
            //Set messageTExt to body
            message.MessageText = "test@gmail.com The most important B dog http:\\\\www.anywhere.com. Further detail of email messages is provided in 3.1.2 below.";
            MessageMetrics metrics = new MessageMetrics();
            

           //Load test abreviations
           List<Abbreviation> abbreviations = new List<Abbreviation>();
           TestDataFacade df = new TestDataFacade();
           df.loadAbbreviations(abbreviations);

           //Create new email handler
           EmailHandler handler = new EmailHandler();

           //Process message
           handler.processMessage(message, metrics, abbreviations);

           string expectedSender = "test@gmail.com";
           string expectedSubject = "The most important B";
           string expectedText = "dog <URL Quarantined> Further detail of email messages is provided in 3.1.2 below.";

           Assert.Equal(expectedSender, message.MessageSender);
           Assert.Equal(expectedSubject, message.MessageSubject);
           Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testEmailProcessMessageCorrectOutputMaxText()
        {
            //Create new message and message metrics
            EmailMessage message = new EmailMessage();
            message.MessageType = MessageType.Email;
            //Set messageId to header
            message.MessageId = "E1294567704";
            //Set messageTExt to body
            message.MessageText = "test@gmail.com The most important B dog http:\\\\www.anywhere.com. Further detail of email messages is provided in 3.1.2 below. fhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfudfhudfhudfhudhfudfhudfhudfhudfhudfhfhudfsasasssss";
            MessageMetrics metrics = new MessageMetrics();


            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new email handler
            EmailHandler handler = new EmailHandler();

            try
            {
                //Process message
                handler.processMessage(message, metrics, abbreviations);
            }
            catch (Exception ex)
            {
                string expectedMessage = "Character limit is 1028 characters for email text";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testSIREmailProcessMessageCorrectOutput()
        {
            //Create new message and message metrics
            EmailMessage message = new EmailMessage();
            message.MessageType = MessageType.Email;
            //Set messageId to header
            message.MessageId = "E1294567704";
            //Set messageTExt to body
            message.MessageText = "test@gmail.com SIR 07/11/98\r\nSort Code: 99-99-99\r\nNature of Incident: Theft\r\nThe most important B4N to remember is to add the #dog ADN code. A mobile LOL number in the United Kingdom always starts. contain embedded hyperlinks in the form of standard URLs e.g. http:\\\\www.anywhere.com. Further detail of email messages is provided in 3.1.2 below.";
            MessageMetrics metrics = new MessageMetrics();


            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new email handler
            EmailHandler handler = new EmailHandler();

            //Process message
            handler.processMessage(message, metrics, abbreviations);

            string expectedSender = "test@gmail.com";
            string expectedSubject = "SIR 07/11/98";
            string expectedText = "Sort Code: 99-99-99\rNature of Incident: Theft\rThe most important B4N to remember is to add the #dog ADN code. A mobile LOL number in the United Kingdom always starts. contain embedded hyperlinks in the form of standard URLs e.g. <URL Quarantined> Further detail of email messages is provided in 3.1.2 below.";

            Assert.Equal(expectedSender, message.MessageSender);
            Assert.Equal(expectedSubject, message.MessageSubject);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testTweetProcessMessageCorrectOutput()
        {
            //Create new message and message metrics
            SmsMessage message = new SmsMessage();
            message.MessageType = MessageType.SMS;
            //Set messageId to header
            message.MessageId = "T1294567701";
            //Set messageTExt to body
            message.MessageText = "@Ben The most important LTM to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL";
            MessageMetrics metrics = new MessageMetrics();

            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new tweet handler
            TweetHandler handler = new TweetHandler();

            //Process message
            handler.processMessage(message, metrics, abbreviations);

            string expectedSender = "@Ben";
            string expectedText = "The most important LTM<Laugh to myself> to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL<Laughing out loud>";

            Assert.Equal(expectedSender, message.MessageSender);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testTweetProcessMessageCorrectOutputMaxText()
        {
            //Create new message and message metrics
            SmsMessage message = new SmsMessage();
            message.MessageType = MessageType.SMS;
            //Set messageId to header
            message.MessageId = "T1294567701";
            //Set messageTExt to body
            message.MessageText = "@Ben The most important LTM to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL number in the United Kingdom always starts.";
            MessageMetrics metrics = new MessageMetrics();

            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new tweet handler
            TweetHandler handler = new TweetHandler();

            try
            {
                //Process message
                handler.processMessage(message, metrics, abbreviations);
            }
            catch (Exception ex)
            {
                string expectedMessage = "Character limit is 140 characters for tweet text";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testTweetProcessMessageCorrectOutputMaxTextUsername()
        {
            //Create new message and message metrics
            SmsMessage message = new SmsMessage();
            message.MessageType = MessageType.SMS;
            //Set messageId to header
            message.MessageId = "T1294567701";
            //Set messageTExt to body
            message.MessageText = "@thisisatestuser3 The most important LTM to remember is to add the #dog LYLAS<Love you like a sis> code. A mobile LOL number in the United Kingdom always starts.";
            MessageMetrics metrics = new MessageMetrics();

            //Load test abreviations
            List<Abbreviation> abbreviations = new List<Abbreviation>();
            TestDataFacade df = new TestDataFacade();
            df.loadAbbreviations(abbreviations);

            //Create new tweet handler
            TweetHandler handler = new TweetHandler();

            try
            {
                //Process message
                handler.processMessage(message, metrics, abbreviations);
            }
            catch (Exception ex)
            {
                string expectedMessage = "Character limit is 140 characters for tweet username";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testAddHashtag()
        {
            MessageMetrics metrics = new MessageMetrics();

            string hashtag = "#test";
            metrics.addHashtag(hashtag);

            string expectedHashtag = "#test";
            string actualHashtag = metrics.getHashtags()[0].Title;
            int expectedHashtagCount = 1;
            int actualHashtagCount = metrics.getHashtags()[0].Count;
            int expectedListSize= 1;

            Assert.Equal(expectedHashtag, actualHashtag);
            Assert.Equal(expectedHashtagCount, actualHashtagCount);
            Assert.Equal(expectedListSize, metrics.getHashtags().Count);
        }

        [Fact]
        public void testAddExistingHashtag()
        {
            MessageMetrics metrics = new MessageMetrics();

            string hashtag = "#test";
            metrics.addHashtag(hashtag);

            //Add the same hashtag
            metrics.addHashtag(hashtag);

            string expectedHashtag = "#test";
            string actualHashtag = metrics.getHashtags()[0].Title;
            int expectedHashtagCount = 2;
            int actualHashtagCount = metrics.getHashtags()[0].Count;
            int expectedListSize = 1;

            Assert.Equal(expectedHashtag, actualHashtag);
            Assert.Equal(expectedHashtagCount, actualHashtagCount);
            Assert.Equal(expectedListSize, metrics.getHashtags().Count);
        }

        [Fact]
        public void testAddHashtagWithEmptyString()
        {
            MessageMetrics metrics = new MessageMetrics();

            string hashtag = "";
            string expectedMessage = "Empty hashtag string";

            try
            {
                //Add the same hashtag
                metrics.addHashtag(hashtag);
            }
            catch(Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testAddSir()
        {
            MessageMetrics metrics = new MessageMetrics();

            string sortcode = "99-99-99";
            string noi = "Theft";
            metrics.addSir(sortcode, noi);

            string expectedSortcode = "99-99-99";
            string actualSortCode = metrics.getSirs()[0].SortCode;
            string expectedNoi = "Theft";
            string actualNoi = metrics.getSirs()[0].NatureOfIncident;
            int expectedListSize = 1;

            Assert.Equal(expectedSortcode, actualSortCode);
            Assert.Equal(expectedNoi, actualNoi);
            Assert.Equal(expectedListSize, metrics.getSirs().Count);
        }

        [Fact]
        public void testAddSirWithEmptyString()
        {
            MessageMetrics metrics = new MessageMetrics();

            string sc = "";
            string noi = "";
            string expectedMessage = "Empty sortcode or noi";

            try
            {
                //Add the same hashtag
                metrics.addSir(sc, noi);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testAddMention()
        {
            MessageMetrics metrics = new MessageMetrics();

            string m = "@test";
            metrics.addMention(m);

            string expectedMention = "@test";
            string actualMention = metrics.getMentions()[0].Username;
            int expectedListSize = 1;

            Assert.Equal(expectedMention, actualMention);
            Assert.Equal(expectedListSize, metrics.getMentions().Count);
        }

        [Fact]
        public void testAddMentionWithEmptyString()
        {
            MessageMetrics metrics = new MessageMetrics();

            string m = "";
            string expectedMessage = "Empty mention string";

            try
            {
                //Add the same hashtag
                metrics.addMention(m);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testAddUrl()
        {
            MessageMetrics metrics = new MessageMetrics();

            string m = "https://www.test.com";
            metrics.addUrl(m);

            string expectedMention = "https://www.test.com";
            string actualMention = metrics.getQuarantineList()[0].Address;
            int expectedListSize = 1;

            Assert.Equal(expectedMention, actualMention);
            Assert.Equal(expectedListSize, metrics.getQuarantineList().Count);
        }

        [Fact]
        public void testAddUrlEmptyString()
        {
            MessageMetrics metrics = new MessageMetrics();

            string url = "";
            string expectedMessage = "Empty url string";

            try
            {
                //Add the same hashtag
                metrics.addUrl(url);
            }
            catch (Exception ex)
            {
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testGetHashtags()
        {
            MessageMetrics metrics = new MessageMetrics();
            string hashtag = "#test";

            metrics.addHashtag(hashtag);

            Assert.NotEmpty(metrics.getHashtags());
        }

        [Fact]
        public void testGetSirs()
        {
            MessageMetrics metrics = new MessageMetrics();
            string sortcode = "99-99-99";
            string noi = "Theft";
            metrics.addSir(sortcode, noi);

            Assert.NotEmpty(metrics.getSirs());
        }

        [Fact]
        public void testGetMentions()
        {
            MessageMetrics metrics = new MessageMetrics();
            string m = "@test";
            metrics.addMention(m);

            Assert.NotEmpty(metrics.getMentions());
        }

        [Fact]
        public void testGetQuarantineList()
        {
            MessageMetrics metrics = new MessageMetrics();
            string m = "https://www.test.com";
            metrics.addUrl(m);

            Assert.NotEmpty(metrics.getQuarantineList());
        }

        [Fact]
        public void testCreateSmsMessage()
        {
            MessageFactory mf = new MessageFactory();

            string header = "S";
            string body = "Test";


            MessageType expectedType = MessageType.SMS;
            string expectedText = "Test";

            Message message = mf.createMessage(header, body);

            Assert.Equal(expectedType, message.MessageType);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testCreateEmailMessage()
        {
            MessageFactory mf = new MessageFactory();

            string header = "E";
            string body = "Test";


            MessageType expectedType = MessageType.Email;
            string expectedText = "Test";

            Message message = mf.createMessage(header, body);

            Assert.Equal(expectedType, message.MessageType);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testCreateTweetMessage()
        {
            MessageFactory mf = new MessageFactory();

            string header = "T";
            string body = "Test";


            MessageType expectedType = MessageType.Tweet;
            string expectedText = "Test";

            Message message = mf.createMessage(header, body);

            Assert.Equal(expectedType, message.MessageType);
            Assert.Equal(expectedText, message.MessageText);
        }

        [Fact]
        public void testGetSmsHandler()
        {
            MessageFactory mf = new MessageFactory();

            string header = "S";
            string body = "Test";

            Message message = mf.createMessage(header, body);

            SmsHandler expectedHandler = new SmsHandler();
            IHandler actualHandler = mf.getHandler(message);

            Assert.Equal(expectedHandler.GetType(), actualHandler.GetType());
        }

        [Fact]
        public void testGetTweetHandler()
        {
            MessageFactory mf = new MessageFactory();

            string header = "T";
            string body = "Test";

            Message message = mf.createMessage(header, body);

            TweetHandler expectedHandler = new TweetHandler();
            IHandler actualHandler = mf.getHandler(message);

            Assert.Equal(expectedHandler.GetType(), actualHandler.GetType());
        }

        [Fact]
        public void testGetEmailHandler()
        {
            MessageFactory mf = new MessageFactory();

            string header = "E";
            string body = "Test";

            Message message = mf.createMessage(header, body);

            EmailHandler expectedHandler = new EmailHandler();
            IHandler actualHandler = mf.getHandler(message);

            Assert.Equal(expectedHandler.GetType(), actualHandler.GetType());
        }
    }
}