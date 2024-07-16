using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagementApp.Models
{
    public class CustomerWithContactModel
    {
        public Customer Customer { get; set; }
        public Contact Contact { get; set; }
    }
}