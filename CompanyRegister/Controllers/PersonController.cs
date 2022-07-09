using CompanyRegister.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CompanyRegister.Controllers
{
    [ApiController]
    [Route("api/company/{companyId}/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int companyId)
        {
            _personService.RemoveAll(companyId);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int companyId, [FromBody] CreatePersonDto dto)
        {
            var newPersonId = _personService.Create(companyId, dto);

            return Created($"api/company/{companyId}/person/{newPersonId}", null);
        }

        [HttpGet("{personId}")]
        public ActionResult<PersonDto> Get([FromRoute] int companyId,
            [FromRoute] int personId)
        {
            PersonDto person = _personService.GetById(companyId, personId);
            return Ok(person);
        }

        [HttpGet]
        public ActionResult<List<PersonDto>> Get([FromRoute] int companyId)
        {
            var result = _personService.GetAll(companyId);
            return Ok(result);
        }
    }
}
