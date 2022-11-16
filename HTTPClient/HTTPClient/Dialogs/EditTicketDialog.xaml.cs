using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HTTPClient.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditTicketDialog.xaml
    /// </summary>
    public partial class EditTicketDialog : Window
    {
        private string _week;
        private string _user;
        private string _price;
        public string Week
        {
            get { return textBoxWeekDialog.Text; }
        }
        public string User
        {
            get { return textBoxUserDialog.Text; }
        }
        public string Price
        {
            get { return textBoxPriceDialog.Text; }
        }
        public EditTicketDialog(string week, string user, string price)
        {
            InitializeComponent();
            _price = price;
            _week = week;
            _user = user;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            textBoxWeekDialog.Text = _week;
            textBoxPriceDialog.Text = _price;
            textBoxUserDialog.Text = _user;
        }

        private void buttonOkDialog_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void buttonCancelDialog_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
