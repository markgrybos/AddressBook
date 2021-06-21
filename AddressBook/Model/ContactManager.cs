using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AddressBook.Model
{
    public static class ContactManager
    {
        public static void AddContact(List<Contact> contact, XmlSerializer xml, Contact contactToAdd)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.xml");
            string xmlexist = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))}\\contacts.xml";
            FileStream contactFile;
            if (!File.Exists(xmlexist))
            {
                contactFile = new FileStream(path, FileMode.Create, FileAccess.Write);
                contactFile.Close();
            }
            else 
            {
                contactFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                contact = (List<Contact>)xml.Deserialize(contactFile);
                contactFile.Close();
                
            }
            contactFile = new FileStream(path, FileMode.Open, FileAccess.Write);
            contact.Add(contactToAdd);
            xml.Serialize(contactFile, contact);
            contactFile.Close();
        }

        public static void ReadAllContacts(ObservableCollection<Contact> allcontacts)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.xml");
            string xmlexist = $"{Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData))}\\contacts.xml";
            FileStream contactFile;
            XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
            List<Contact> contactlist = new List<Contact>();
            if (File.Exists(xmlexist))
            {
                contactFile = new FileStream(path, FileMode.Open, FileAccess.Read);
                contactlist = (List<Contact>)xml.Deserialize(contactFile);

            }
            allcontacts.Clear();
            contactlist.ForEach(contact => allcontacts.Add(contact));
        }
    }
}
