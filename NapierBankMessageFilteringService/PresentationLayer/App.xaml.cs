using Autofac;
using BusinessLayer;
using PresentationLayer.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = ContainerConfig.Configure();
            
            var messageBankApp = container.Resolve<IMessageBankFacade>();

            MainWindow mainWindow =  new MainWindow(messageBankApp);
            mainWindow.Show();
        }
    }
}
