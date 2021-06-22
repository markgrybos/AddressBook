using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailID { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        // public Contact() { }

        public Contact() {
            // Removed required properties in the Constructor as it was breaking 
            // app from running the Add Contact page and XML Serializer does it 
            // a different way 
            // ~ Mark

            /*FirstName = "";
            LastName = "";
            PhoneNo ="";
            EmailID = "";
            Address = "";        */

        }

    }
}
