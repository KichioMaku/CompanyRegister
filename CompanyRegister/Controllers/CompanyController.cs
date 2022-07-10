using CompanyRegister.Models;
using CompanyRegister.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;

namespace CompanyRegister.Controllers
{
	[ApiController]
    [Route("api/company")]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet]
		[Authorize(Policy = "HasNationality")]
		[Authorize(Policy = "Atleast20")]
		public ActionResult<IEnumerable<CompanyDto>> GetAll()
		{
			var companiesDtos = _companyService.GetAll();
			return Ok(companiesDtos);
		}

		[HttpGet("{id}")]
		public ActionResult<IEnumerable<CompanyDto>> Get([FromRoute] int id)
		{
			var company = _companyService.GetById(id);

			return Ok(company);
		}

		[HttpPost]
		[Authorize(Roles = "Admin,Manager")]
		public ActionResult CreateCompany([FromBody] CreateCompanyDto dto)
		{
			var userId = int.Parse(User.FindFirst(c => c.Type ==
			ClaimTypes.NameIdentifier).Value);

			var id = _companyService.Create(dto);

			return Created($"/api/restaurant/{id}", null);
		}

		[HttpDelete("{id}")]
		public ActionResult Delete([FromRoute] int id)
		{
			_companyService.Delete(id);
			return NoContent();
		}

		[HttpPut("{id}")]
		public ActionResult Update([FromBody] UpdateCompanyDto dto, [FromRoute] int id)
		{
			_companyService.Update(id, dto);
			return Ok();
		}

	}
}
