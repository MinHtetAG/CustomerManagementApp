using System.Collections.Generic;
using System.Web.Http;
using CustomerManagementApp.Models;
using CustomerManagementApp.Controllers;

namespace CustomerManagementApp.Api
{
    public class CustomerApiController : ApiController
    {
        private readonly CustomerController customerController = new CustomerController();
        private readonly ContactController contactController = new ContactController();

        // POST: api/customers
        [HttpPost]
    public IHttpActionResult PostCustomer(CustomerWithContactModel customerWithContact)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
            var customer = customerWithContact.Customer;
            var contact = customerWithContact.Contact;


            customerController.AddCustomer(customer);

            if (contact != null)
            {
                // Set customer ID for the contact
                contact.CustomerId = customer.CustomerId;

                if (contact.ContactId == 0)
                {
                    contactController.AddContact(contact);
                }
                else
                {
                    contactController.UpdateContact(contact);
                }
            }


            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
    }

    // PUT: api/customers/5
    [HttpPut]     
        public IHttpActionResult PutCustomer(int id, CustomerWithContactModel customerWithContact)
        {
            if (!ModelState.IsValid || id != customerWithContact.Customer.CustomerId)
            {
                return BadRequest();
            }

            var customer = customerWithContact.Customer;
            var contact = customerWithContact.Contact;

            // Update customer
            customerController.UpdateCustomer(customer);

            // If contact is provided, update it
            if (contact != null)
            {
                // Set customer ID for the contact
                contact.CustomerId = customer.CustomerId;

                // Update contact
                contactController.UpdateContact(contact);
            }

            return StatusCode(System.Net.HttpStatusCode.NoContent);
        }


    }
}

 