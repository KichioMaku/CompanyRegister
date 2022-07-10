using CompanyRegister.Entities;
using CompanyRegister.Models;

namespace CompanyRegister.Services
{

	public interface IAccountService
	{
		public void RegisterUser(RegisterUserDto dto);
	}

	public class AccountService
	{
		private readonly CompanyDbContext _context;


		public AccountService(CompanyDbContext context)
		{
			_context = context;

		}

		public void RegisterUser(RegisterUserDto dto)
		{
			var newUser = new User
			{
				Email = dto.Email,
				DateOfBirth = dto.DateOfBirth,
				Nationality = dto.Nationality,
				RoleID = dto.RoleID,
			};
			_context.Users.Add(newUser);
			_context.SaveChanges();
		}
	}
}
