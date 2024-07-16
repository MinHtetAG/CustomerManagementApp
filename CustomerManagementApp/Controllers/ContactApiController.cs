using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CustomerManagementApp.Data;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Controllers
{
    public class ContactApiController : ApiController
    {
        private CustomerDbContext db = new CustomerDbContext();

        // POST api/contactapi/addcontact
        [HttpPost]
        [Route("api/contactapi/addcontact")]
        public IHttpActionResult AddContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contact.ContactId }, contact);
        }

        // PUT api/contactapi/updatecontact/{id}
        [HttpPut]
        [Route("api/contactapi/updatecontact/{id}")]
        public IHttpActionResult UpdateContact(int id, Contact contact)
        {
            if (!ModelState.IsValid || id != contact.ContactId)
            {
                return BadRequest();
            }

            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
