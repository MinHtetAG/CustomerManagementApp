using System;
using System.Web.UI.WebControls;
using CustomerManagementApp.Controllers;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Pages
{
    public partial class Default : System.Web.UI.Page
    {
        private CustomerController customerController = new CustomerController();
        private ContactController contactController = new ContactController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCustomers();
            }
        }

        private void BindCustomers()
        {
            var customers = customerController.GetAllCustomers();
            GridViewCustomers.DataSource = customers;
            GridViewCustomers.DataBind();
        }

        protected void btnAddOrUpdate_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer
            {
                Name = txtName.Text,
                DateOfBirth = DateTime.Parse(txtDOB.Value),
                Gender = txtGender.Text,
                Occupation = txtOccupation.Text,
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
                CustomerId = customer.CustomerId,
                Type = txtContactType.Text,
                Subtype = txtContactSubtype.Text,
                Value = txtContactValue.Text
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

            BindCustomers();
            ClearForm();
        }

        protected void GridViewCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int customerId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"CustomerDetails.aspx?CustomerId={customerId}");
            }
        }

        private void ClearForm()
        {
            txtName.Text = string.Empty;
            txtGender.Text = string.Empty;
            txtOccupation.Text = string.Empty;
            txtContactType.Text = string.Empty;
            txtContactSubtype.Text = string.Empty;
            txtContactValue.Text = string.Empty;

            txtDOB.Attributes["value"] = string.Empty;
            
            ViewState["CustomerId"] = null;
            ViewState["ContactId"] = null;
        }
    }
}
