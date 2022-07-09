using Microsoft.EntityFrameworkCore;

namespace CompanyRegister.Entities
{
	public class CompanyDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Address> Address { get; set; }


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
        }
	}
}
