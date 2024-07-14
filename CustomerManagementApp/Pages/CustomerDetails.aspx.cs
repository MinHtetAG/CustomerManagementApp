using System;
using System.Web.UI;
using CustomerManagementApp.Controllers;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Pages
{
    public partial class CustomerDetails : System.Web.UI.Page
    {
        private CustomerController customerController = new CustomerController();
        private ContactController contactController = new ContactController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["CustomerId"] != null)
                {
                    int customerId;
                    if (int.TryParse(Request.QueryString["CustomerId"], out customerId))
                    {
                        BindCustomerDetails(customerId);
                        BindContactDetails(customerId);

                        // Store customer ID in ViewState for later use
                        ViewState["CustomerId"] = customerId;
                    }
                }
            }
        }

        private void BindCustomerDetails(int customerId)
        {
            Customer customer = customerController.GetCustomerById(customerId);
            if (customer != null)
            {
                txtName.Text = customer.Name;
                txtDOB.Attributes["value"] = customer.DateOfBirth.ToString("yyyy-MM-dd");
                txtGender.Text = customer.Gender;
                txtOccupation.Text = customer.Occupation;

                // Calculate age
                DateTime now = DateTime.Today;
                int age = now.Year - customer.DateOfBirth.Year;
                if (customer.DateOfBirth > now.AddYears(-age))
                    age--;
                // Display age
                lblAge.Text = $"{age} years old";

                
            }
        }

        private void BindContactDetails(int customerId)
        {
            Contact contact = contactController.GetContactByCustomerId(customerId);
            if (contact != null)
            {
                TextBox1.Text = contact.Type;
                TextBox2.Text = contact.Subtype;
                TextBox3.Text = contact.Value;

                // Store contact ID in ViewState for later use
                ViewState["ContactId"] = contact.ContactId;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerId;
            if (!int.TryParse(ViewState["CustomerId"].ToString(), out customerId))
            {
                // Handle scenario where customer ID is not valid
                Response.Redirect("Default.aspx"); // Redirect to default page or handle error
                return;
            }

            Customer customer = new Customer
            {
                CustomerId = customerId,
                Name = txtName.Text,
                DateOfBirth = DateTime.ParseExact(txtDOB.Attributes["value"], "yyyy-MM-dd", null),
                Gender = txtGender.Text,
                Occupation = txtOccupation.Text
            };

            if (ViewState["CustomerId"] == null)
            {
                customerController.AddCustomer(customer);
            }
            else
            {
                customer.CustomerId = (int)ViewState["CustomerId"];
                customerController.UpdateCustomer(customer);
            }

            Contact contact = new Contact
            {
                CustomerId = customerId,
                Type = TextBox1.Text,
                Subtype = TextBox2.Text,
                Value = TextBox3.Text
            };

            if (ViewState["ContactId"] == null)
            {
                contactController.AddContact(contact);
            }
            else
            {
                contact.ContactId = (int)ViewState["ContactId"];
                contactController.UpdateContact(contact);
            }
            
            Response.Redirect($"Default.aspx?CustomerId={customerId}");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int customerId;
            if (!int.TryParse(ViewState["CustomerId"].ToString(), out customerId))
            {
                // Handle scenario where customer ID is not valid
                Response.Redirect("Default.aspx");
                return;
            }

            // Delete contact first (if exists)
            Contact contact = contactController.GetContactByCustomerId(customerId);
            if (contact != null)
            {
                contactController.DeleteContact(contact.ContactId);
            }

            // Delete customer
            customerController.DeleteCustomer(customerId);

            // Redirect to default page after deletion
            Response.Redirect("Default.aspx");
        }
       protected void btnBackToDefault_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx"); 
        }
    }
}