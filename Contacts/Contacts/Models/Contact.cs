using System.Collections.Generic;

namespace Contacts
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}