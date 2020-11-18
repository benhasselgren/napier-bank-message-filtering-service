using DataLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using XTests.TestClasses;
using Xunit;

namespace XTests
{
    /// <summary>
    /// Data Layer Unit tests
    /// </summary>
    public class DataSystemLayerUnitTests
    {
        [Fact]
        public void testLoadDataWithFile()
        {
            string path = "..\\..\\..\\Data\\test.csv";

            DataFacade df = new DataFacade();

            List<string> data = df.loadData(path);

            int expectedLength = 18;

            string expectedLastString = "S1234567701,,+447911123456 The most important B4N to remember is to add the international ADN code.";

            Assert.Equal(expectedLength, data.Count);
            Assert.Equal(expectedLastString, data[data.Count-1]);
        }

        [Fact]
        public void testLoadDataWithNoFile()
        {
            string path = "";

            DataFacade df = new DataFacade();

            try
            {
                List<string> data = df.loadData(path);
            }
            catch(Exception ex)
            {
                string expectedMessage = "File does not exist";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testSaveDataWithFile()
        {
            string path = "valid path";

            //Create new sms
            SmsMessage sms = new SmsMessage();
            sms.MessageType = MessageType.SMS;
            sms.MessageId = "S1234567701";
            sms.MessageSender = "+447911123456";
            sms.MessageText = "This is a test message";
            //Add sms to list
            List<Message> processedMessages = new List<Message>();
            processedMessages.Add(sms);

            TestDataFacade df = new TestDataFacade();

            string expectedString = "[{\"MessageType\":0,\"MessageId\":\"S1234567701\",\"MessageSender\":\"+447911123456\",\"MessageText\":\"This is a test message\"}]";
            string actualString = df.saveData(processedMessages, path, "TESTMODE");

            Assert.Equal(expectedString, actualString);
        }

        [Fact]
        public void testSaveDataWithNoFile()
        {
            string path = "";
            //Create new sms
            SmsMessage sms = new SmsMessage();
            sms.MessageType = MessageType.SMS;
            sms.MessageId = "S1234567701";
            sms.MessageSender = "+447911123456";
            sms.MessageText = "This is a test message";
            //Add sms to list
            List<Message> processedMessages = new List<Message>();
            processedMessages.Add(sms);

            DataFacade df = new DataFacade();

            try
            {
                df.saveData(processedMessages, path);
            }
            catch (Exception ex)
            {
                string expectedMessage = "Filepath needs to be provided";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testSaveDataWithEmptyList()
        {
            string path = "validpath";

            List<Message> processedMessages = new List<Message>();

            DataFacade df = new DataFacade();

            try
            {
                df.saveData(processedMessages, path);
            }
            catch (Exception ex)
            {
                string expectedMessage = "No messages to save";
                Assert.Equal(expectedMessage, ex.Message);
            }
        }

        [Fact]
        public void testLoadAbbreviationsReturnsList()
        {
            List<Abbreviation> abbrvs = new List<Abbreviation>();

            DataFacade df = new DataFacade();

            df.loadAbbreviations(abbrvs);

            Assert.NotEmpty(abbrvs);
        }
    }
}