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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {

            InitializeComponent();
            loadContacts();
        }

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.ShowDialog();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Person selectedContact = (Person)cDataBinding.SelectedItem;
            if (selectedContact != null)
            {
                EditContact contact = new EditContact(selectedContact);
                contact.Show();
                this.Title = (cDataBinding.SelectedItem as Person).Name;
                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select a contact");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Person selectedContact = (Person)cDataBinding.SelectedItem;
            if (selectedContact !=null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show($"Are you sure you want to delete this contact : {selectedContact.FirstName}  {selectedContact.LastName}", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var message = Method.DeleteContact(selectedContact);
                    MessageBox.Show(message);
                    loadContacts();
                }
            }
            else
            {
                MessageBox.Show("You need to select a contact");
            }
        }

        private void cDataBinding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void cDataBinding_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Person selectedContact = (Person)cDataBinding.SelectedItem;
            if (cDataBinding != null)
            {
                ContactDetails contactDetails = new ContactDetails(selectedContact);
                contactDetails.Show();
                this.Title = (cDataBinding.SelectedItem as Person).Name;
            }

        }

        private void loadContacts()
        {
            List<Person> contactList = Method.GetAllContacts();
            cDataBinding.ItemsSource = contactList;
            contactList.Sort(delegate (Person x, Person y)
            {
                return x.FirstName.CompareTo(y.FirstName);
            });

        }
    }

}
