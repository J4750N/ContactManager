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
    public partial class EditContact : Window
    {
        EditContact editContact;
        public EditContact(Person contact)
        {
            InitializeComponent();
            IdContact.Content = contact.Id;
            FirstNameTextBox.Text = contact.FirstName;
            LastNameTextBox.Text = contact.LastName;
            PhoneTextBox.Text = contact.Phone;
            EmailTextBox.Text = contact.Email;

        }

        private void btnSaveContact_Click(object sender, RoutedEventArgs e)
        {
            
            Person contact = new Person();
            contact.Id = (int)IdContact.Content;
            contact.FirstName = FirstNameTextBox.Text;
            contact.LastName = LastNameTextBox.Text;
            contact.Phone = PhoneTextBox.Text;
            contact.Email = EmailTextBox.Text;

            var message = Method.EditContact(contact);
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
