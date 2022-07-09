using AutoMapper;
using CompanyRegister.Entities;
using CompanyRegister.Exceptions;
using CompanyRegister.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRegister.Services
{
    public interface IPersonService
    {
        int Create(int companyId, CreatePersonDto dto);
        PersonDto GetById(int companyId, int personId);
        public List<PersonDto> GetAll(int companyId);
        void RemoveAll(int companyId);
    }

    public class PersonService : IPersonService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;

        public PersonService(CompanyDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        public int Create(int companyId, CreatePersonDto dto)
        {
            var company = GetCompanyById(companyId);
            if (company is null)
            {
                throw new NotFoundException($"Company with id {companyId} was not found!");
            }
            var personEntity = _mapper.Map<Person>(dto);

            personEntity.CompanyId = companyId;

            _context.Persons.Add(personEntity);
            _context.SaveChanges();
            return personEntity.Id;
        }

        public PersonDto GetById(int companyId, int personId)
        {
            var company = GetCompanyById(companyId);
            if (company is null)
            {
                throw new NotFoundException($"Company with id {companyId} was not found!");
            }

            var person = _context.Persons.FirstOrDefault(x => x.Id == personId);
            if (person is null || person.CompanyId != companyId)
            {
                throw new NotFoundException($"Person not found!");
            }
            var personDto = _mapper.Map<PersonDto>(person);

            return personDto;
        }

        public List<PersonDto> GetAll(int companyId)
        {
            var company = GetCompanyById(companyId);

            var personDtos = _mapper.Map<List<PersonDto>>(company.Persons);
            return personDtos;
        }

        public void RemoveAll(int companyId)
        {
            var company = GetCompanyById(companyId);

            _context.RemoveRange(company.Persons);
            _context.SaveChanges();
        }

        private Company GetCompanyById(int companyId)
        {
            var company = _context.Companies
                 .Include(x => x.Persons)
                 .FirstOrDefault(x => x.Id == companyId);
            if (company is null)
            {
                throw new NotFoundException($"Company with id {companyId} was not found!");
            }
            return company;
        }
    }
}
