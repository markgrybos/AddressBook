using AddressBook.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            this.InitializeComponent();
            allcontacts = new ObservableCollection<Contact>();
            ContactManager.ReadAllContacts(allcontacts);
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
           // ContactsSplitview.IsPaneOpen = !ContactsSplitview.IsPaneOpen;
        }
    }
}
