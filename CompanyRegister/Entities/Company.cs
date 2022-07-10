using System.Collections.Generic;

namespace CompanyRegister.Entities
{
	public class Company
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nip { get; set; }
        public string Krs { get; set; }
        public string Regon { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public int? CreatedById { get; set; }
        public virtual User CreatedBy { get; set; }
        public int AddressId { get; set; }
		public virtual Address Address { get; set; }
		public virtual List<Person> Persons { get; set; }
	}
}
