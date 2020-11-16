using System;
using System.IO;
using System.Windows;
using BusinessLayer;
using Microsoft.Win32;
using Models;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for InputWIndow.xaml
    /// </summary>
    public partial class InputWIndow : Window
    {
        private IMessageBankFacade bankMessages;
        private Message currentMessage;
        private int messageProcessedCount;

        public InputWIndow()
        {
            InitializeComponent();
        }

        public InputWIndow(IMessageBankFacade mbf)
        {
            InitializeComponent();
            this.bankMessages = mbf;

            //Hide processed message panel
            ProcessedMessagePanel.Visibility = Visibility.Hidden;

            //set processed message count to 0
            messageProcessedCount = 0;


        }

        private void process_message_btn_Click(object sender, RoutedEventArgs e)
        {
            string header = header_input.Text;
            string body = body_input.Text;
            Message message = new Message();

            //Try and add a message
            try
            {
                //Set error message to empty string
                error_message_title.Text = "";
                //Call process message method
                message = bankMessages.processMessage(header, body);
            }
            catch(Exception ex)
            {
                //Show error message
                error_message_title.Text = ex.Message;
            }

            //Show processed message panel but collapse email subject initially
            ProcessedMessagePanel.Visibility = Visibility.Visible;
            email_panel.Visibility = Visibility.Collapsed;

            //Display message
            //Type
            type_title.Content = message.MessageType;
            //Id
            id_input.Text = message.MessageId;
            //Sender
            sender_input.Text = message.MessageSender;
            
            //Subject if message type is email
            if (message.MessageType == MessageType.Email)
            {
                //Show email panel
                email_panel.Visibility = Visibility.Visible;
                
                //Cast message to email message type
                EmailMessage emailMessage = (EmailMessage)message;

                subject_input.Text = emailMessage.MessageSubject;
            }

            //Text
            text_input.Text = message.MessageText;

            //Save current message in variable
            currentMessage = message;
        }

        private void add_message_btn_Click(object sender, RoutedEventArgs e)
        {
            bool verifyMessage = false;
            try
            {
                //Add message to list
                verifyMessage = this.bankMessages.verifyMessage(currentMessage);
            }
            catch(Exception ex)
            {
                //Show error message
                error_message_title.Text = ex.Message;
            }

            if(verifyMessage)
            {
                //Update processed message count and output value
                messageProcessedCount++;
                number_processed_title.Content = messageProcessedCount + " processed";

                //Clear form
                ProcessedMessagePanel.Visibility = Visibility.Hidden;
            }
        }

        private void finish_input_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";

            if (folderBrowser.ShowDialog() == true)
            {
                //Get the user to choose path
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                bankMessages.saveMessages(folderPath);

                //Open main window and pass data back
                MainWindow main = new MainWindow(bankMessages, true);
                main.Show();
                this.Close();
            }
        }
    }
}
