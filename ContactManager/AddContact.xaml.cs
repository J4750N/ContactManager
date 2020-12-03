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
        AddContact addContact;
        public AddContact()
        {
            InitializeComponent();

            

        }

        private void btnCreateNewContact_Click(object sender, RoutedEventArgs e)
        {
            
            List<Contact> contactList = new List<Contact>();
            var name = NameTextBox.Text;
            var phone = PhoneTextBox.Text;
            var email = EmailTextBox.Text;

            contactList.Add(new Contact() { Name = name, Phone = phone, Email = email });

            
            addContact.Close();

            
        }
    }
}
