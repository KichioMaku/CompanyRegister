using AutoMapper;
using CompanyRegister.Entities;
using CompanyRegister.Exceptions;
using CompanyRegister.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRegister.Services
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDto> GetAll();
		public CompanyDto GetById(int id);
		public int Create(CreateCompanyDto dto);
		public void Delete(int id);
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

		public CompanyDto GetById(int id)
		{
			var company = _dbContext
				.Companies
				.Include(r => r.Address)
				.Include(r => r.Persons)
				.FirstOrDefault(x => x.Id == id);

			if (company is null)
			{
				throw new NotFoundException($"Restaurant with id = {id} not found.");
			}
			var result = _mapper.Map<CompanyDto>(company);
			return result;
		}

		public int Create(CreateCompanyDto dto)
		{
			var company = _mapper.Map<Company>(dto);
			_dbContext.Add(company);
			_dbContext.SaveChanges();
			return company.Id;
		}
		public void Delete(int id)
		{
			var company = _dbContext
				.Companies
				.FirstOrDefault(x => x.Id == id);
			if (company is null)
				throw new NotFoundException("Restaurant not found");

			_dbContext.Companies.Remove(company);
			_dbContext.SaveChanges();
		}
	}
}
