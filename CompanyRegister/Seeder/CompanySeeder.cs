using CompanyRegister.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRegister.Seeder
{
	public class CompanySeeder
	{
            private readonly CompanyDbContext _dbContext;

            public CompanySeeder(CompanyDbContext dbContext)
            {
                _dbContext = dbContext;
            }


            public void Seed()
            {
                if (_dbContext.Database.CanConnect())
                {
                    if (!_dbContext.Companies.Any())
                    {
                        var companies = GetCompanies();
                        _dbContext.Companies.AddRange(companies);
                        _dbContext.SaveChanges();
                    }
                }
            }

        private IEnumerable<Company> GetCompanies()
        {
            var companies = new List<Company>()
            {


                new Company
                {
                        Name = "Med-Pharm",
                        Description = "Med-Pharm is an international company that specializes in the manufacture of pharmaceutical products",
                        Nip = "6312516302",
                        Krs = "0000374328",
                        Regon = "240594048",
                        ContactEmail = "contact@medpharm.com",
                        ContactNumber = "256231945",
                        Persons = new List<Person>
                        {
                            new Person { FirstName = "Janusz", LastName = "Korwin-Mikke", Description = "Członek Zarządu"},
                            new Person { FirstName = "Andrzej", LastName = "Nochal", Description = "Członek Zarządu"},
                            new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Główny Analityk"},
                            new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
                        },
                        Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}



                 }
            };
            return companies;

        }
    }
}
