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
using Windows.UI.Popups;
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
        Contact selected;
        public MainPage()

        {
            OnLoad();

            
            this.InitializeComponent();

        }
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Contact selectedcontact = (Contact)e.Parameter;
            selected = ContactManager.GetContact(selectedcontact);
            DeleteSelectedItem.Visibility = Visibility.Visible;
            UnselectedContact.Visibility = Visibility.Collapsed;
            SelectedContactName.Visibility = Visibility.Visible;
            SelectedContactPhoneNo.Visibility = Visibility.Visible;
            SelectedContactEmail.Visibility = Visibility.Visible;
            SelectedContactAddress.Visibility = Visibility.Visible;
           
            PersonPicture.Visibility = Visibility.Visible;

            EditButton.Visibility = Visibility.Visible;

        }*/

        private void OnLoad()
        {
            allcontacts = new ObservableCollection<Contact>();

            ContactManager.ReadAllContacts(allcontacts);
            allcontacts.OrderBy(x => x.LastName);
            DataContext = allcontacts;
            this.InitializeComponent();
            EditButton.Visibility = Visibility.Collapsed;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewContact));
        }

        private void ContactList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var contact = (Contact)e.ClickedItem;
            selected = ContactManager.GetContact(contact);
            DeleteSelectedItem.Visibility = Visibility.Visible;
            UnselectedContact.Visibility = Visibility.Collapsed;
            SelectedContactName.Visibility = Visibility.Visible;
            SelectedContactPhoneNo.Visibility = Visibility.Visible;
            SelectedContactEmail.Visibility = Visibility.Visible;
            SelectedContactAddress.Visibility = Visibility.Visible;
            //SelectedContactFullName.Visibility = Visibility.Visible;
            PersonPicture.Visibility = Visibility.Visible;
            EditButton.Visibility = Visibility.Visible;

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
                DeleteSelectedItem.Visibility = Visibility.Collapsed;
                UnselectedContact.Visibility = Visibility.Visible;
                EditButton.Visibility = Visibility.Collapsed;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            

            this.Frame.Navigate(typeof(EditContact),selected);
            
        }

        /*private void DeleteSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            //  var dialog = new MessageDialog("Do you want to delete");
            // await dialog.ShowAsync();
            ListView lv = sender as ListView;
            var contact = e.ClickedItem as Contact;
            ContactManager.DeleteContact(selected, allcontacts);
            
            //SelectedContactName.Visibility = Visibility.Collapsed;

            // var lastname = SelectedContactName.;


            UnselectedContact.Visibility = Visibility.Visible;
            SelectedContactPhoneNo.Visibility = Visibility.Collapsed;
            SelectedContactEmail.Visibility = Visibility.Collapsed;
            SelectedContactAddress.Visibility = Visibility.Collapsed;
            //SelectedContactFullName.Visibility = Visibility.Collapsed;
            PersonPicture.Visibility = Visibility.Collapsed;
            DeleteSelectedItem.Visibility = Visibility.Collapsed;
            //allcontacts.Clear();
            OnLoad();
        }*/

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selected = ContactList.SelectedItem;
            ContactManager.DeleteContact((Contact)selected, allcontacts);
            EditButton.Visibility = Visibility.Collapsed;
            DeleteFlyout.Hide();
            
        }

        public void SetSelectNavigationItem(Contact selected)
        {
            ContactList.SelectedItem = ContactManager.GetContact(selected);
        }
    }
}
