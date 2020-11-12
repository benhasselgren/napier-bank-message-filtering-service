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
        private MessageBankFacade bankMessages;

        public InputWIndow()
        {
            InitializeComponent();
        }

        public InputWIndow(MessageBankFacade mbf)
        {
            InitializeComponent();
            this.bankMessages = mbf;
        }
    }
}
