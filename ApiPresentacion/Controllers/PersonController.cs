using Domain.Entities;
using Domain.Services.Persons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ApiPresentacion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Person>> Get()
        {
            var data = await _personService.GetAllAsync();

            return data;
        }

        [HttpGet]
        [Route("GetPerson")]
        [SwaggerOperation(Summary = "Obtiene una persona por su cuil y género.")]
        [SwaggerResponse(200, "Se encontró la persona y se devuelve.", typeof(Person))]
        [SwaggerResponse(404, "No se encontró la persona con los parámetros especificados.")]
        [SwaggerResponse(500, "Error interno del servidor.")]
        public async Task<IActionResult> Get([FromQuery]string cuil,[FromQuery] string gender)
        {
            try
            {
                var data = await _personService.GetByCuilAndGenderAsync(cuil, gender);

                if (data == null)
                {
                    return NotFound();
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


