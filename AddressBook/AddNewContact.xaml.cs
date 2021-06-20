using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AddressBook.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewContact : Page
    {
        private XmlSerializer XMLSerial;
        private List<Contact> contactList;
        public AddNewContact()
        {
            InitializeComponent();
            contactList = new List<Contact>();
            XMLSerial = new XmlSerializer(typeof(List<Contact>));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contactToAdd = new Contact();
            contactToAdd.FirstName = NewFirstName.Text;
            contactToAdd.LastName = NewLastName.Text;
            contactToAdd.EmailID = NewEmailId.Text;
            contactToAdd.PhoneNo = NewPhoneNumber.Text;
            contactToAdd.Address = NewAddress.Text;

            ContactManager.AddContact(contactList, XMLSerial, contactToAdd);

            NewFirstName.Text = String.Empty;
            NewLastName.Text = String.Empty;
            NewPhoneNumber.Text = String.Empty;
            NewEmailId.Text = String.Empty;
            NewAddress.Text = String.Empty;

            //var newcontact = new Contact(NewName.ToString(), NewPhoneNumber.ToString(), NewEmailId.ToString(),NewAddress.ToString());

            //var contact = new Contact(NewName.Text, NewPhoneNumber.Text, NewEmailId.Text, NewAddress.Text);

            //System.Xml.Serialization.XmlSerializer writer =
            //new System.Xml.Serialization.XmlSerializer(typeof(Contact));

            //var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\data.xml";
            //System.IO.FileStream file = System.IO.File.Create(path);

            //writer.Serialize(file, newcontact);
            //file.Close();
        }

    }
}
