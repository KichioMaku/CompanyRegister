using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;

namespace CompanyRegister.Entities
{
	public class CompanyDbContext : DbContext
	{
		private string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=CompanyDB;Trusted_Connection=True";

		public DbSet<Company> Companies { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Address> Address { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }  



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Company>()
				.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50); 

			modelBuilder.Entity<Company>()
				.Property(x => x.Description)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.City)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .IsRequired();
            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
