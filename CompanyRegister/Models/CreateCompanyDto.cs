using System.ComponentModel.DataAnnotations;

namespace CompanyRegister.Models
{
	public class CreateCompanyDto
	{
        public string Name { get; set; }
        public string Description { get; set; }
        public string Nip { get; set; }
        public string Krs { get; set; }
        public string Regon { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        public string PostalCode { get; set; }
    }
}
