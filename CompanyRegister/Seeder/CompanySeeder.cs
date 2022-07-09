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
							new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Członek Zarządu"},
							new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Prokura"},
						},
						Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}
				 },

				new Company
				{
						Name = "BrukCam",
						Description = "BrukCam is a company that specializes in the manufacture of red bricks",
						Nip = "6452229479",
						Krs = "0000268113",
						Regon = "240542301",
						ContactEmail = "contact@brukcam.com",
						ContactNumber = "238413749",
						Persons = new List<Person>
						{
							new Person { FirstName = "Tomasz", LastName = "Pindol", Description = "Członek Zarządu"},
							new Person { FirstName = "Damian", LastName = "Studnia", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Warszawa", Street = "Fabryczna 23", PostalCode = "30-421"}
				 },

				new Company
				{
						Name = "LuxMed",
						Description = "Luxmed is a private medical clinic",
						Nip = "2322552302",
						Krs = "0000274358",
						Regon = "240594048",
						ContactEmail = "contact@luxmed.com",
						ContactNumber = "328456123",
						Persons = new List<Person>
						{
							new Person { FirstName = "Kewin", LastName = "Zalewski", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Lublin", Street = "Zielona 23", PostalCode = "30-183"}
				 },


				new Company
				{
						Name = "Gemini",
						Description = "Gemini is a company that delivers goods to pharmacies",
						Nip = "6352526322",
						Krs = "0000532358",
						Regon = "460793248",
						ContactEmail = "contact@gemini.com",
						ContactNumber = "321574483",
						Persons = new List<Person>
						{
							new Person { FirstName = "Mieszko", LastName = "Górski", Description = "Członek Zarządu"},
							new Person { FirstName = "Oskar", LastName = "Jankowski", Description = "Wspólnik"},
						},
						Address = new Address { City = "Warszawa", Street = "Żółta 15", PostalCode = "30-329"}
				 },

				new Company
				{
						Name = "Dr MAX",
						Description = "Dr MAX is a company that delivers goods to wholesalers",
						Nip = "1352516323",
						Krs = "0000993963",
						Regon = "842453369",
						ContactEmail = "contact@drmax.com",
						ContactNumber = "564488522",
						Persons = new List<Person>
						{
							new Person { FirstName = "Jędrzej", LastName = "Rutkowski", Description = "Wspólnik"},
							new Person { FirstName = "Piotr", LastName = "Kowalczyk", Description = "Wspólnik"},
						},
						Address = new Address { City = "Warszawa", Street = "Czerwona 69", PostalCode = "30-312"}
				 },

				new Company
				{
						Name = "Markexshare",
						Description = "Markexshare is company that specializes in the stock market",
						Nip = "9623824797",
						Krs = "0000347221",
						Regon = "366353435",
						ContactEmail = "contact@markexshare.com",
						ContactNumber = "867657748",
						Persons = new List<Person>
						{
							new Person { FirstName = "Paweł", LastName = "Gajewski", Description = "Członek Zarządu"},
							new Person { FirstName = "Bogumił", LastName = "Makowski", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Opole", Street = "Opolska 14", PostalCode = "24-120"}
				}
				// },

				//new Company
				//{
				//		Name = "Med-Pharm",
				//		Description = "Med-Pharm is an international company that specializes in the manufacture of pharmaceutical products",
				//		Nip = "6312516302",
				//		Krs = "0000374328",
				//		Regon = "240594048",
				//		ContactEmail = "contact@medpharm.com",
				//		ContactNumber = "256231945",
				//		Persons = new List<Person>
				//		{
				//			new Person { FirstName = "Janusz", LastName = "Korwin-Mikke", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Andrzej", LastName = "Nochal", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Główny Analityk"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//		},
				//		Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}
				// },

				//new Company
				//{
				//		Name = "Med-Pharm",
				//		Description = "Med-Pharm is an international company that specializes in the manufacture of pharmaceutical products",
				//		Nip = "6312516302",
				//		Krs = "0000374328",
				//		Regon = "240594048",
				//		ContactEmail = "contact@medpharm.com",
				//		ContactNumber = "256231945",
				//		Persons = new List<Person>
				//		{
				//			new Person { FirstName = "Janusz", LastName = "Korwin-Mikke", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Andrzej", LastName = "Nochal", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Główny Analityk"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//		},
				//		Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}
				// },

				//new Company
				//{
				//		Name = "Med-Pharm",
				//		Description = "Med-Pharm is an international company that specializes in the manufacture of pharmaceutical products",
				//		Nip = "6312516302",
				//		Krs = "0000374328",
				//		Regon = "240594048",
				//		ContactEmail = "contact@medpharm.com",
				//		ContactNumber = "256231945",
				//		Persons = new List<Person>
				//		{
				//			new Person { FirstName = "Janusz", LastName = "Korwin-Mikke", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Andrzej", LastName = "Nochal", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Główny Analityk"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//		},
				//		Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}
				// },

				//new Company
				//{
				//		Name = "Med-Pharm",
				//		Description = "Med-Pharm is an international company that specializes in the manufacture of pharmaceutical products",
				//		Nip = "6312516302",
				//		Krs = "0000374328",
				//		Regon = "240594048",
				//		ContactEmail = "contact@medpharm.com",
				//		ContactNumber = "256231945",
				//		Persons = new List<Person>
				//		{
				//			new Person { FirstName = "Janusz", LastName = "Korwin-Mikke", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Andrzej", LastName = "Nochal", Description = "Członek Zarządu"},
				//			new Person { FirstName = "Mirosław", LastName = "Ciętynochal", Description = "Główny Analityk"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//			new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Programista"},
				//		},
				//		Address = new Address { City = "Kraków", Street = "Polna 12", PostalCode = "32-195"}
				// }

			};
			return companies;

		}
	}
}
