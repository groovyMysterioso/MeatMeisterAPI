using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeatMeisterAPI.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName => $"{LastName}, {FirstName}";
        public string DisplayName => $"{FirstName} {LastName}";

        public Contact(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public Contact(string fullName, string phoneNumber)
        {
            var nameArray = fullName.Split(' ');
            FirstName = nameArray[0];
            LastName = nameArray[1];
            PhoneNumber = phoneNumber;
        }
        public Contact()
        { }
    }
}