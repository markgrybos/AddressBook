using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        XmlSerializer myXmlSerializer;
        List<Contact> contacts;
        FileStream myXmlFile;
        public MainPage()
        {
            this.InitializeComponent();
            contacts = new List<Contact>();
            myXmlSerializer = new XmlSerializer(typeof(List<Contact>));
            myXmlFile = new FileStream("Assets/Contacts.Xml",FileMode.Open,FileAccess.Write);
            Contact c1 = new Contact();
            c1.Name = "Andy";
            c1.Phone = "9346923";
            c1.Email = "skjdfks";
            c1.Address = "khfksf";
            contacts.Add(c1);
            myXmlSerializer.Serialize(myXmlFile,contacts);
           // myXmlFile = new FileStream("Assets/Contacts.Xml",FileMode.Open,FileAccess.Read);
            //contacts = (List<Contact>)myXmlSerializer.Deserialize(myXmlFile);
            


        }

        private void ListOfLettersView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

            ContactsSplitview.IsPaneOpen = !ContactsSplitview.IsPaneOpen;
            this.Frame.Navigate(typeof(AddNewContact));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ContactsSplitview.IsPaneOpen = !ContactsSplitview.IsPaneOpen;
        }
    }
}
