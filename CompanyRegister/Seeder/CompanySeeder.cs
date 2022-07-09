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
							new Person { FirstName = "Jarosław", LastName = "Michas", Description = "Wspólnik"},
						},
						Address = new Address { City = "Cracow", Street = "Polna 12", PostalCode = "32-195"}
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
						Address = new Address { City = "Warsaw", Street = "Fabryczna 23", PostalCode = "30-421"}
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
						Address = new Address { City = "Warsaw", Street = "Żółta 15", PostalCode = "30-329"}
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
							new Person { FirstName = "Piotr", LastName = "Kowalczyk", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Warsaw", Street = "Czerwona 69", PostalCode = "30-312"}
				 },

				new Company
				{
						Name = "Markexshare",
						Description = "Markexshare is a company that specializes in the stock market",
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
				},

				new Company
				{
						Name = "GreenLife",
						Description = "GreenLife is a company that produces ECO friendly kitchen tools",
						Nip = "3862353865",
						Krs = "0000217828",
						Regon = "774933835",
						ContactEmail = "contact@greenlife.com",
						ContactNumber = "524579939",
						Persons = new List<Person>
						{
							new Person { FirstName = "Konstanty", LastName = "Lis", Description = "Członek Zarządu"},
							new Person { FirstName = "Eryk", LastName = "Baranowski", Description = "Członek Zarządu"},
							new Person { FirstName = "Diego", LastName = "Sawicki", Description = "Członek Zarządu"},
							new Person { FirstName = "Adam", LastName = "Bąk", Description = "Wspólnik"},
							new Person { FirstName = "Amadeusz", LastName = "Stępień", Description = "Wspólnik"},
						},
						Address = new Address { City = "Szczecin", Street = "Osiedle Złote 144", PostalCode = "12-124"}
				 },

				new Company
				{
						Name = "Farmapol",
						Description = "Farmapol is a company which specializes in production of carpets",
						Nip = "9937727875",
						Krs = "0000871322",
						Regon = "274374872",
						ContactEmail = "kontakt@farmapol.com.pl",
						ContactNumber = "976533843",
						Persons = new List<Person>
						{
							new Person { FirstName = "Lucjan", LastName = "Sikora", Description = "Członek Zarządu"},
							new Person { FirstName = "Alojzy", LastName = "Kołodziej", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Grudziądz", Street = "Szczytowa 3", PostalCode = "15-463"}
				 },

				new Company
				{
						Name = "Crem-atory",
						Description = "Crem-atory is a company that specializes in the crematorial activities",
						Nip = "9285536955",
						Krs = "0000128259",
						Regon = "483898564",
						ContactEmail = "kontakt@crematory.com.pl",
						ContactNumber = "494394824",
						Persons = new List<Person>
						{
							new Person { FirstName = "Krzysztof", LastName = "Kononowicz", Description = "Prezes"},
							new Person { FirstName = "Jerzy", LastName = "Popiołek", Description = "Członek Zarządu"},
						},
						Address = new Address { City = "Białystok", Street = "Szkolna 17", PostalCode = "15-640"}
				 },

				new Company
				{
						Name = "ExtraPonton",
						Description = "ExtraPonton is a company that specializes in a production of inflatables",
						Nip = "8358742772",
						Krs = "0000853877",
						Regon = "677646655",
						ContactEmail = "kontakt@extraponton.com.pl",
						ContactNumber = "247786854",
						Persons = new List<Person>
						{
							new Person { FirstName = "Michał", LastName = "Włodarczyk", Description = "Członek Zarządu"},
							new Person { FirstName = "Kacper", LastName = "Błaszczyk", Description = "Członek Zarządu"},
							new Person { FirstName = "Ludwik", LastName = "Mazur", Description = "Prezes"},
						},
						Address = new Address { City = "Gdańsk", Street = "Morska 235", PostalCode = "13-246"}
				 }

			};
			return companies;

		}
	}
}
