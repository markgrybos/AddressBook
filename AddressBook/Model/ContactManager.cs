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
            //var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\data.xml";
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            contact.Add(contactToAdd);
            xml.Serialize(file, contact);
            file.Close();
        }
    }
}
