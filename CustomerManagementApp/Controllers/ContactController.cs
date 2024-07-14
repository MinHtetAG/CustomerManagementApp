using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerManagementApp.Data;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Controllers
{
    public class ContactController
    {
        private CustomerDbContext db = new CustomerDbContext();

        public List<Contact> GetContactsForCustomer(int customerId)
        {
            return db.Contacts.Where(c => c.CustomerId == customerId).ToList();
        }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void UpdateContact(Contact contact)
        {
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteContact(int contactId)
        {
            var contact = db.Contacts.Find(contactId);
            if (contact != null)
            {
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
        }
        public void DeleteContactsByCustomerId(int customerId)
        {
            var contacts = db.Contacts.Where(c => c.CustomerId == customerId).ToList();
            db.Contacts.RemoveRange(contacts);
            db.SaveChanges();
        }
        public Contact GetContactByCustomerId(int customerId)
        {
            return db.Contacts.FirstOrDefault(c => c.CustomerId == customerId);
        }
        public int GetContactIdByCustomerId(int customerId)
        {
            var contact = db.Contacts.FirstOrDefault(c => c.CustomerId == customerId);
            return contact != null ? contact.ContactId : 0;
        }
    }
}