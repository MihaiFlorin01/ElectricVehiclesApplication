using Abstractions;
using Entities;
using Infrastructure.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        private readonly DatabaseSettings _dbSettings;
        public DbSet<Vehicle>? Vehicles { get; set; }
        public DbSet<VehicleType>? VehicleTypes { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Invoice>? Invoices { get; set; }
        public DbSet<Rental>? Rentals { get; set; }
        public DbSet<User>? Users { get; set; }

        public DatabaseContext(IOptions<DatabaseSettings> optionSettings)
        {
            _dbSettings = optionSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbSettings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasKey(x => x.Id);
            modelBuilder.Entity<Vehicle>().Property(x => x.Type).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Vehicle>().Property(x => x.RegisterDate).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<VehicleType>().HasKey(x => x.Id);
            modelBuilder.Entity<VehicleType>().Property(x => x.Description).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<VehicleType>().Property(x => x.PricePerMinute).IsRequired();

            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            modelBuilder.Entity<Customer>().Property(x => x.Name).HasMaxLength(200).IsRequired();
            modelBuilder.Entity<Customer>().Property(x => x.BillingAddress).HasMaxLength(200).IsRequired();

            modelBuilder.Entity<Invoice>().HasKey(x => x.Id);
            modelBuilder.Entity<Invoice>().Property(x => x.GrossAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.VAT).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.NetAmount).IsRequired();
            modelBuilder.Entity<Invoice>().Property(x => x.Paid).IsRequired();

            modelBuilder.Entity<Rental>().HasKey(x => x.Id);
            modelBuilder.Entity<Rental>().Property(x => x.VehicleId).IsRequired();
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
