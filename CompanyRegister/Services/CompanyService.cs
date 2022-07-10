using AutoMapper;
using CompanyRegister.Authorization;
using CompanyRegister.Entities;
using CompanyRegister.Exceptions;
using CompanyRegister.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CompanyRegister.Services
{
	public interface ICompanyService
	{
		IEnumerable<CompanyDto> GetAll();
		public CompanyDto GetById(int id);
		public int Create(CreateCompanyDto dto, int userId);
		public void Delete(int id, ClaimsPrincipal user);
		public void Update(int id, UpdateCompanyDto dto, ClaimsPrincipal user);
	}
	public class CompanyService : ICompanyService
	{
		private readonly CompanyDbContext _dbContext;
		private readonly IMapper _mapper;
		private readonly ILogger<CompanyService> _logger;
		private readonly IAuthorizationService _authorizationService;

		public CompanyService(CompanyDbContext dbContext, ILogger<CompanyService> logger, IMapper mapper, IAuthorizationService authorizationService)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_logger = logger;
			_authorizationService = authorizationService;
		}
		public IEnumerable<CompanyDto> GetAll()
		{
			var companies = _dbContext
				.Companies
				.Include(x => x.Address)
				.Include(x => x.Persons)
				.ToList();
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
				throw new NotFoundException($"Company with id = {id} not found.");
			}
			var result = _mapper.Map<CompanyDto>(company);
			return result;
		}

		public int Create(CreateCompanyDto dto, int userId)
		{
			var company = _mapper.Map<Company>(dto);
			company.CreatedById = userId;
			_dbContext.Add(company);
			_dbContext.SaveChanges();
			return company.Id;
		}
		public void Delete(int id, ClaimsPrincipal user)
		{
			_logger.LogWarning($"Company with id: {id} DELETE action invoked");
			var company = _dbContext
				.Companies
				.FirstOrDefault(x => x.Id == id);
			if (company is null)
				throw new NotFoundException("Company not found");

			var authorizationResult = _authorizationService.AuthorizeAsync(user, company, new ResourceOperationRequirement(ResourceOperation.Delete)).Result;

			if (!authorizationResult.Succeeded)
			{
				throw new ForbidException();
			}

			_dbContext.Companies.Remove(company);
			_dbContext.SaveChanges();
		}
		public void Update(int id, UpdateCompanyDto dto, ClaimsPrincipal user)
		{
			var company = _dbContext
				.Companies
				.FirstOrDefault(x => x.Id == id);
			if (company is null)
				throw new NotFoundException("Company not found");

			var authorizationResult = _authorizationService.AuthorizeAsync(user, company, new 
				ResourceOperationRequirement(ResourceOperation.Update)).Result;

			if (!authorizationResult.Succeeded)
			{
				throw new ForbidException();
			}

			company.Name = dto.Name;
			company.Description = dto.Description;
			company.ContactEmail = dto.ContactEmail;
		
			_dbContext.SaveChanges();
		}
	}
}
