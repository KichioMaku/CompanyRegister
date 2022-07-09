using CompanyRegister.Entities;
using CompanyRegister.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRegister.Services
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDto> GetAll();
	}
	public class CompanyService : ICompanyService
	{
		private readonly CompanyDbContext _dbContext;

		public CompanyService(CompanyDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<CompanyDto> GetAll()
		{
			var companies = _dbContext.Companies.Include(x => x.Address).Include(x=>x.Persons).ToList();

		}
	}
}
