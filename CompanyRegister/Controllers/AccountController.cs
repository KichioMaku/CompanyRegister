using Microsoft.AspNetCore.Mvc;

namespace CompanyRegister.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		[HttpPost("register")]
		public ActionResult RegisterUser([FromBody] RegisterUserDto dto)
		{

		}

	}
}
