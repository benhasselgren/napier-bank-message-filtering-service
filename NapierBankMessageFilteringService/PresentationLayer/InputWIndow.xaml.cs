using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BusinessLayer;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for InputWIndow.xaml
    /// </summary>
    public partial class InputWIndow : Window
    {
        private IMessageBankFacade bankMessages;

        public InputWIndow()
        {
            InitializeComponent();
        }

        public InputWIndow(IMessageBankFacade mbf)
        {
            InitializeComponent();
            this.bankMessages = mbf;
        }

        private void process_message_btn_Click(object sender, RoutedEventArgs e)
        {
            string header = header_input.Text;
            string body = body_input.Text;

            try
            {
                bankMessages.processMessage(header, body);
            }
            catch(Exception ex)
            {
                header_title.Content = ex.Message;
            }
        }
    }
}
