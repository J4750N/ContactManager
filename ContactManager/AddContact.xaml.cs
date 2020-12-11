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
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();

            

        }

        private void btnCreateNewContact_Click(object sender, RoutedEventArgs e)
        {
            
            Person contact = new Person();
            contact.FirstName = FirstNameTextBox.Text;
            contact.LastName = LastNameTextBox.Text;
            contact.Phone = PhoneTextBox.Text;
            contact.Email = EmailTextBox.Text;

            var instanceA = Method.Instance;
            var message = instanceA.AddContact(contact);
            MessageBox.Show(message);
            //addContact.Close();

            
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();

        }
    }
}
