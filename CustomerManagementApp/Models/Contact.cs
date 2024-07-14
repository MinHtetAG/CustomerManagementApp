using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int CustomerId { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public string Value { get; set; }
        public virtual Customer Customer { get; set; }
    }
}