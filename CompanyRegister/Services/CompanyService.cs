using AutoMapper;
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
		private readonly IMapper _mapper;

		public CompanyService(CompanyDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}
		public IEnumerable<CompanyDto> GetAll()
		{
			var companies = _dbContext.Companies.Include(x => x.Address).Include(x=>x.Persons).ToList();
			var companiesDtos = _mapper.Map<List<CompanyDto>>(companies);
			return companiesDtos;
		}
	}
}
