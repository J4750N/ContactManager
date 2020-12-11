using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;

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
            DataContext = new PhoneType();
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
            if (selectedContact != null)
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

        private void btnImportContact_Click(object sender, RoutedEventArgs e)
        {
            string[] contactlines;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                contactlines = File.ReadAllLines(openFileDialog.FileName);
                foreach (string line in contactlines)
                {
                    Person person = new Person();
                    string[] splitline = line.Split(',');
                    person.FirstName = splitline[0];
                    person.LastName = splitline[1];
                    person.Phone = splitline[2];
                    person.Email = splitline[3];
                    Method.AddContact(person);
                }
            }

            loadContacts();

        }

        private void btnExportContact_Click(object sender, RoutedEventArgs e)
        {
            List<Person> person = Method.GetAllContacts();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                using (StreamWriter sw = File.CreateText(@"C:\Users\Jayson Taylor\Documents\ExportContact.csv"))
                {
                    foreach(Person p in person)
                    {
                        sw.WriteLine(p.ToString());
                    }
                }
            }
        }
    }
}


