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
            OpenFileDialog dlg = new OpenFileDialog();

            // Set filter default file extension 
            dlg.DefaultExt = ".csv";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Call method
                bankMessages.processMessagesByFile(dlg.FileName);
            }


            //Save messages
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
                string folderPath = System.IO.Path.GetDirectoryName(folderBrowser.FileName);
                bankMessages.saveMessages(folderPath);

                listOfMentions.ItemsSource = bankMessages.getMessageMetrics().getMentions();
                sirList.ItemsSource = bankMessages.getMessageMetrics().getSirs();
                trendingList.ItemsSource = bankMessages.getMessageMetrics().getHashtags();
            }
        }
    }
}
