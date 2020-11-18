using Autofac;
using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using XTests.TestClasses;

namespace XTests
{
    public static class TestContainerConfig
    {
        public static IContainer Configure( )
        {
            var builder = new ContainerBuilder();

            //Register types
            builder.RegisterType<TestDataFacade>().As<IDataFacade>();
            builder.RegisterType<SmsHandler>().As<IHandler>();
            builder.RegisterType<EmailHandler>().As<IHandler>();
            builder.RegisterType<TweetHandler>().As<IHandler>();
            builder.RegisterType<MessageFactory>().As<IMessageFactory>();
            builder.RegisterType<MessageBankFacade>().As<IMessageBankFacade>();
            builder.RegisterType<MessageMetrics>().As<IMessageMetrics>();

            return builder.Build();
        }

        public static IContainer Configure(string DATAFACADE)
        {
            var builder = new ContainerBuilder();

            //Register types
            builder.RegisterType<DataFacade>().As<IDataFacade>();
            builder.RegisterType<SmsHandler>().As<IHandler>();
            builder.RegisterType<EmailHandler>().As<IHandler>();
            builder.RegisterType<TweetHandler>().As<IHandler>();
            builder.RegisterType<MessageFactory>().As<IMessageFactory>();
            builder.RegisterType<MessageBankFacade>().As<IMessageBankFacade>();
            builder.RegisterType<MessageMetrics>().As<IMessageMetrics>();

            return builder.Build();
        }
    }
}
