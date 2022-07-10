using CompanyRegister.Entities;
using CompanyRegister.Models;
using Microsoft.AspNetCore.Identity;

namespace CompanyRegister.Services
{

	public interface IAccountService
	{
		public void RegisterUser(RegisterUserDto dto);
	}

	public class AccountService : IAccountService
	{
		private readonly CompanyDbContext _context;
		private readonly IPasswordHasher<User> _passwordHasher;

		public AccountService(CompanyDbContext context, IPasswordHasher<User> passwordHasher)
		{
			_context = context;
			_passwordHasher = passwordHasher;
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

			var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);
			newUser.PasswordHash = hashedPassword;
			_context.Users.Add(newUser);
			_context.SaveChanges();
		}
	}
}
