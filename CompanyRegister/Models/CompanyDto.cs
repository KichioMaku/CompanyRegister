using CompanyRegister.Entities;
using System.Collections.Generic;

namespace CompanyRegister.Models
{
	public class CompanyDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Nip { get; set; }
		public string Krs { get; set; }
		public string Regon { get; set; }
		public string ContactEmail { get; set; }
		public string ContactNumber { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string PostalCode { get; set; }
		public virtual List<PersonDto> Persons { get; set; }
	}
}
