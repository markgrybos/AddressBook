﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Windows.UI.Popups;

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
                contactFile.Close();

            }
            allcontacts.Clear();
            contactlist.Sort((x, y) => string.Compare(x.LastName, y.LastName));
            contactlist.ForEach(contact => allcontacts.Add(contact));


        }

        public static Contact GetContact(Contact selectedContact)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.xml");
            FileStream contactFile;
            XmlSerializer xml = new XmlSerializer(typeof(List<Contact>));
            List<Contact> contactlist = new List<Contact>();
            contactFile = new FileStream(path, FileMode.Open, FileAccess.Read);
            contactlist = (List<Contact>)xml.Deserialize(contactFile);
            contactFile.Close();

            var lookForContact = contactlist.First(f => f.FirstName == selectedContact.FirstName && f.LastName == selectedContact.LastName);

            return (Contact)lookForContact;

        }
        public static void DeleteContact(string fullname)
        {
           
          

            XmlDocument doc = new XmlDocument();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "contacts.xml");
            doc.Load(path);
            //var root = doc.SelectNodes("//ArrayOfContact//Contact[@FirstName='Moha']");
            //  Console.WriteLine("Hello");

            // var targetNode = root.SelectSingleNode("//Contact[FullName='Moha Zain']");
            try
            {
                foreach (XmlNode xNode in doc.SelectNodes("ArrayOfContact / Contact"))
                    if (xNode.SelectSingleNode("FullName").InnerText == fullname)
                    {
                        xNode.ParentNode.RemoveChild(xNode);
                    }
                doc.Save(path);
                
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Exception thrown {0} ",e);
            }
            
        }

    


    }
}
