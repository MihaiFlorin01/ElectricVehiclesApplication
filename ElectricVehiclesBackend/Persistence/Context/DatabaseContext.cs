using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Bike>? Bikes { get; set; }
        public DbSet<BikeType>? BikeTypes { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<Rental>? Rentals { get; set; }
        public DbSet<User>? Users { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().HasKey(x => x.Id);
            modelBuilder.Entity<Bike>().Property(x => x.Type).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Bike>().Property(x => x.RegisterDate).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<BikeType>().HasKey(x => x.Id);
            modelBuilder.Entity<BikeType>().Property(x => x.Description).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<BikeType>().Property(x => x.PricePerMinute).IsRequired();

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.BillingAddress).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<Invoice>().HasKey(x => x.Id);
            modelBuilder.Entity<Invoice>().Property(x => x.GrossAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.VAT).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.NetAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.Paid).IsRequired();

            modelBuilder.Entity<Rental>().HasKey(x => x.Id);
            modelBuilder.Entity<Rental>().Property(x => x.BikeId).IsRequired();
            modelBuilder.Entity<Rental>().Property(x => x.CustomerId).IsRequired();
            modelBuilder.Entity<Rental>().Property(x => x.StartDateTime).IsRequired();
            modelBuilder.Entity<Rental>().Property(x => x.EndDateTime).IsRequired();
            modelBuilder.Entity<Rental>().Property(x => x.InvoiceId).IsRequired();

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Username).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.Role).HasMaxLength(200).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
