using System.Text.Json.Serialization;

namespace CompanyRegister.Entities
{
	public class Person
	{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
