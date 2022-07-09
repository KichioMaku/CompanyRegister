using CompanyRegister.Models;
using CompanyRegister.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
		public ActionResult<IEnumerable<CompanyDto>> GetAll([FromQuery] string searchPhrase)
		{
			var restaurantsDtos = _companyService.GetAll();
			return Ok(restaurantsDtos);
		}
	}
}
