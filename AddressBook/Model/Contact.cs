using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public class Contact
    {
        public string Name { get; set; }
        public string EmailID { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public Contact() { }

        public Contact(string name,string phone,string email, string address) { 
            Name=name;
            PhoneNo=phone;
            EmailID = email;
            Address = address;
        

        }

    }
}
