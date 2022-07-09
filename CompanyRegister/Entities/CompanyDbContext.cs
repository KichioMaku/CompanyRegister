using Microsoft.EntityFrameworkCore;

namespace CompanyRegister.Entities
{
	public class CompanyDbContext : DbContext
	{
		public DbSet<Company> Companies { get; set; }
		public DbSet<Person> Persons { get; set; }
		public DbSet<Address> Address { get; set; }
	}
}
