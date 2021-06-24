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
        
        public MainPage()

        {
            OnLoad();

            
            this.InitializeComponent();

        }
        private void OnLoad()
        {
            allcontacts = new ObservableCollection<Contact>();

            ContactManager.ReadAllContacts(allcontacts);
            allcontacts.OrderBy(x => x.LastName);
            DataContext = allcontacts;
            this.InitializeComponent();

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddNewContact));
        }

        private void ContactList_ItemClick(object sender, ItemClickEventArgs e)
        {
            DeleteSelectedItem.Visibility = Visibility.Visible;
            var contact = (Contact)e.ClickedItem;
            Contact selected= ContactManager.GetContact(contact);
            UnselectedContact.Visibility = Visibility.Collapsed;
            SelectedContactName.Visibility = Visibility.Visible;
            SelectedContactPhoneNo.Visibility = Visibility.Visible;
            SelectedContactEmail.Visibility = Visibility.Visible;
            SelectedContactAddress.Visibility = Visibility.Visible;
            SelectedContactFullName.Visibility = Visibility.Visible;
            PersonPicture.Visibility = Visibility.Visible;


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

        private void DeleteSelectedItem_Click(object sender, RoutedEventArgs e)
        {
            //  var dialog = new MessageDialog("Do you want to delete");
            // await dialog.ShowAsync();
            var firstname = SelectedContactName.Text;
            
            
            ContactManager.DeleteContact(firstname);
            SelectedContactName.Visibility = Visibility.Collapsed;

            // var lastname = SelectedContactName.;


            UnselectedContact.Visibility = Visibility.Visible;
            SelectedContactPhoneNo.Visibility = Visibility.Collapsed;
            SelectedContactEmail.Visibility = Visibility.Collapsed;
            SelectedContactAddress.Visibility = Visibility.Collapsed;
            SelectedContactFullName.Visibility = Visibility.Collapsed;
            PersonPicture.Visibility = Visibility.Collapsed;
            DeleteSelectedItem.Visibility = Visibility.Collapsed;
            //allcontacts.Clear();
            OnLoad();







        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
