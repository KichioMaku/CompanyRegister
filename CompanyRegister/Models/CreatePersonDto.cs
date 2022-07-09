using System.ComponentModel.DataAnnotations;

namespace CompanyRegister.Models
{
	public class CreatePersonDto
	{
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
    }
}
