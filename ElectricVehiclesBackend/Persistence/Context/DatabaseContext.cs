using Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Bike>().Property(x => x.Type).HasColumnName("type").HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Bike>().Property(x => x.RegisterDate).HasColumnName("register_date").HasColumnType("datetime").IsRequired();

            modelBuilder.Entity<BikeType>().HasKey(x => x.Id);
            modelBuilder.Entity<BikeType>().Property(x => x.Description).HasColumnName("description").HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<BikeType>().Property(x => x.PricePerMinute).HasColumnName("price_per_minute").HasColumnType("decimal(5, 2)").IsRequired();

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasColumnName("name").HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.BillingAddress).HasColumnName("billing_address").HasColumnType("varchar(200)").IsRequired();

            modelBuilder.Entity<Invoice>().HasKey(x => x.Id);
            modelBuilder.Entity<Invoice>().Property(x => x.GrossAmount).HasColumnName("gross_amount").HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Invoice>().Property(x => x.VAT).HasColumnName("VAT").HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Invoice>().Property(x => x.NetAmount).HasColumnName("net_amount").HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Invoice>().Property(x => x.Paid).HasColumnName("paid");

            modelBuilder.Entity<Rental>().HasKey(x => x.Id);
            modelBuilder.Entity<Rental>().Property(x => x.BikeId).HasColumnName("bike_id").HasColumnType("int");
            modelBuilder.Entity<Rental>().Property(x => x.CustomerId).HasColumnName("customer_id").HasColumnType("int");
            modelBuilder.Entity<Rental>().Property(x => x.StartDateTime).HasColumnName("start_date_time").HasColumnType("datetime");
            modelBuilder.Entity<Rental>().Property(x => x.EndDateTime).HasColumnName("end_date_time").HasColumnType("datetime");
            modelBuilder.Entity<Rental>().Property(x => x.InvoiceId).HasColumnName("invoice_id").HasColumnType("int");

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Username).HasColumnName("username").HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasColumnName("password").HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasColumnName("email").HasColumnType("varchar(200)");
            modelBuilder.Entity<User>().Property(x => x.Role).HasColumnName("role");

            base.OnModelCreating(modelBuilder);
        }
    }
}
