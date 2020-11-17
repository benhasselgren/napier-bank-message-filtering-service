using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Windows;
using System.IO;
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
            sirList.ItemsSource = bankMessages.getMessageMetrics().getSirs();
            trendingList.ItemsSource = bankMessages.getMessageMetrics().getHashtags();
        }

        private void add_messages_Click(object sender, RoutedEventArgs e)
        {
            InputWIndow inputWindow = new InputWIndow(bankMessages);
            inputWindow.Show();
            this.Close();
        }

        private void add_messages_file_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            OpenFileDialog readFileDialog = new OpenFileDialog();

            // Set dialog setup properties
            readFileDialog.DefaultExt = ".csv";
            readFileDialog.Title = "Read Unprocessed Messages";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = readFileDialog.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Call method to process messages
                bankMessages.processMessagesByFile(readFileDialog.FileName);
            }

            //Save to a file by users choice
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Set dialog setup properties
            saveFileDialog.Title = "Save Processed Messages";
            saveFileDialog.Filter = "Json files (*.json)|*.json";
            saveFileDialog.InitialDirectory = @"C:\";   


            result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                bankMessages.saveMessages(saveFileDialog.FileName);

                listOfMentions.ItemsSource = bankMessages.getMessageMetrics().getMentions();
                sirList.ItemsSource = bankMessages.getMessageMetrics().getSirs();
                trendingList.ItemsSource = bankMessages.getMessageMetrics().getHashtags();
            }
        }
    }
}
