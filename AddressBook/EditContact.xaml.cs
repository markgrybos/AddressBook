using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AddressBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditContact : Page
    {
        Contact selectedcontact;
        public EditContact()
        {
            this.InitializeComponent();
                        
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedcontact = (Contact)e.Parameter;
            EditFirstName.Text = selectedcontact.FirstName;
            EditLastName.Text = selectedcontact.LastName;
            EditPhoneNumber.Text = selectedcontact.PhoneNo;
            EditEmailId.Text = selectedcontact.EmailID;
            EditAddress.Text = selectedcontact.Address;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Contact UpdatedContact = new Contact();
            UpdatedContact.FirstName = EditFirstName.Text;
            UpdatedContact.LastName = EditLastName.Text;
            UpdatedContact.PhoneNo = EditPhoneNumber.Text;
            UpdatedContact.EmailID = EditEmailId.Text;
            UpdatedContact.Address = EditAddress.Text;
            ContactManager.EditContact(selectedcontact,UpdatedContact);
            var dialog = new MessageDialog("Contact updated successfully.");
            await dialog.ShowAsync();
            this.Frame.Navigate(typeof(MainPage));

        }
    }
}
