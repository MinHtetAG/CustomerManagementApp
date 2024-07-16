using System.Data.Entity;
using CustomerManagementApp.Models;

namespace CustomerManagementApp.Data
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext() : base("name=CustomerManagementDBConnectionString")
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);

            modelBuilder.Entity<Contact>()
                .HasRequired(c => c.Customer)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CustomerId)
                .WillCascadeOnDelete(true);     
        }
    }
}