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

            List<Person> contactList = Method.GetAllContacts();

            //contactList.Add(new Contact() { Name = "Arianne Bonneau", Phone = "450-893-8976", Email = "abonneau@gmail.com" });
            //contactList.Add(new Contact() { Name = "Anthony Toner", Phone = "514-782-3847", Email = "atoner@gmail.com" });
            //contactList.Add(new Contact() { Name = "Jayson Taylor", Phone = "450-738-9090", Email = "jtaylor@gmail.com" });
            //contactList.Add(new Contact() { Name = "Anne Drolet", Phone = "438-273-4546", Email = "adrolet@gmail.com" });
            //contactList.Add(new Contact() { Name = "André Leblanc", Phone = "438-281-6732", Email = "aleblanc@gmail.com" });

            cDataBinding.ItemsSource = contactList;

            contactList.Sort(delegate(Person x, Person y) {
                return x.FirstName.CompareTo(y.FirstName); 
            });

            
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
    }

}
