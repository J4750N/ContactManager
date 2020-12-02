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
    /// Interaction logic for ContactDetails.xaml
    /// </summary>
    public partial class ContactDetails : Window
    {
        Contact contact;
        public ContactDetails(Contact contact)
        {
            InitializeComponent();
            this.contact = contact;
            NameTextBox.Text = contact.Name;
            PhoneTextBox.Text = contact.Phone;
            EmailTextBox.Text = contact.Email;
        }
    }
}
