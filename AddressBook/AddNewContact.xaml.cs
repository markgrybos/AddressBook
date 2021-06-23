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
using System.Windows;
using Windows.UI.Popups;


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

        private async void SaveButton_Click(object sender, RoutedEventArgs e)

        {
            if (String.IsNullOrEmpty(NewFirstName.Text))
            {
                var dialog = new MessageDialog("Please enter first name");
                await dialog.ShowAsync();


            }
            else
            {
                Contact contactToAdd = new Contact();
                contactToAdd.FirstName = TCase(NewFirstName.Text);
                contactToAdd.LastName = TCase(NewLastName.Text);
                contactToAdd.EmailID = NewEmailId.Text;
                contactToAdd.PhoneNo = NewPhoneNumber.Text;
                contactToAdd.Address = NewAddress.Text;
                contactToAdd.FullName = $"{contactToAdd.FirstName} {contactToAdd.LastName}";

                ContactManager.AddContact(contactList, XMLSerial, contactToAdd);

                

                NewFirstName.Text = String.Empty;
                NewLastName.Text = String.Empty;
                NewPhoneNumber.Text = String.Empty;
                NewEmailId.Text = String.Empty;
                NewAddress.Text = String.Empty;
                var dialog = new MessageDialog("Contact added successfully.");
                await dialog.ShowAsync();

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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NewFirstName.Text = String.Empty;
            NewLastName.Text = String.Empty;
            NewPhoneNumber.Text = String.Empty;
            NewEmailId.Text = String.Empty;
            NewAddress.Text = String.Empty;

        }

        public static String TCase(String strParam)
        {
            String strTitleCase = strParam.Substring(0, 1).ToUpper();
            strParam = strParam.Substring(1).ToLower();
            String strPrev = "";


            for (int iIndex = 0; iIndex < strParam.Length; iIndex++)
            {
                if (iIndex > 1)
                {
                    strPrev = strParam.Substring(iIndex - 1, 1);
                }
                if (strPrev.Equals(" ") ||
                    strPrev.Equals("\t") ||
                    strPrev.Equals("\n") ||
                    strPrev.Equals("."))
                {
                    strTitleCase += strParam.Substring(iIndex, 1).ToUpper();
                }
                else
                {
                    strTitleCase += strParam.Substring(iIndex, 1);
                }
            }
            return strTitleCase;
        }
    }
}
