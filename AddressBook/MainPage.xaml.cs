using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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
        private ObservableCollection<Contact> allcontacts;
        
        public MainPage()
        {
            allcontacts = new ObservableCollection<Contact>();
            allcontacts.OrderBy(x => x.LastName);
            ContactManager.ReadAllContacts(allcontacts);
            DataContext = allcontacts;
            this.InitializeComponent();

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewContact));
        }

        private void ContactList_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            var contact = (Contact)e.ClickedItem;
            Contact selected= ContactManager.GetContact(contact);
            UnselectedContact.Visibility = Visibility.Collapsed;
            SelectedContactName.Visibility = Visibility.Visible;


            /*else if(SelectedContactName.Visibility != Visibility.Visible)
            {
                UnselectedContact.Visibility = Visibility.Visible;
            }*/

        }

        private void ContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ContactList.SelectedIndex == -1)
            {
                SelectedContactName.Visibility = Visibility.Collapsed;
                
                UnselectedContact.Visibility = Visibility.Visible;
            }
        }
    }
}
