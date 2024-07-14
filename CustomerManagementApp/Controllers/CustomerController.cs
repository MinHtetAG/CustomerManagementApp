using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerManagementApp.Data;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Controllers
{
    public class CustomerController
    {
        private CustomerDbContext db = new CustomerDbContext();

        public List<Customer> GetAllCustomers()
        {
            return db.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return db.Customers.Find(customerId);
        }

        public void AddCustomer(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteCustomer(int customerId)
        {
            var customer = db.Customers.Find(customerId);
            if (customer != null)
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
        }
    }
}