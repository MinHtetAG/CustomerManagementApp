using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementApp.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Occupation { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}