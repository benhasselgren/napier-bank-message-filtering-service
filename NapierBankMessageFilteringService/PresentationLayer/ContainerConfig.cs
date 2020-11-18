using Autofac;
using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
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
