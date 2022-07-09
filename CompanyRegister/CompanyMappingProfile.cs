using AutoMapper;
using CompanyRegister.Entities;
using CompanyRegister.Models;

namespace CompanyRegister
{
	public class CompanyMappingProfile : Profile
	{
		public CompanyMappingProfile()
		{
			CreateMap<Company, CompanyDto>()
			   .ForMember(m => m.City, c => c.MapFrom(s => s.Address.City))
			   .ForMember(m => m.Street, c => c.MapFrom(s => s.Address.Street))
			   .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
			CreateMap<Person, PersonDto>();

			CreateMap<CreateCompanyDto, Company>()
				.ForMember(r => r.Address,
				c => c.MapFrom(dto => new Address()
				{
					City = dto.City,
					Street = dto.Street,
					PostalCode = dto.PostalCode
				}));

			CreateMap<UpdateCompanyDto, Company>();
		}
	}
}
