using Autofac;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMessageBankFacade bankMessages;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IMessageBankFacade mbf)
        {
            this.bankMessages = mbf;
            InitializeComponent();
            listOfMentions.ItemsSource = bankMessages.getMessageMetrics().getMentions();
        }

        private void add_messages_Click(object sender, RoutedEventArgs e)
        {
            InputWIndow inputWindow = new InputWIndow(bankMessages);
            inputWindow.Show();
            this.Close();
        }
    }
}
