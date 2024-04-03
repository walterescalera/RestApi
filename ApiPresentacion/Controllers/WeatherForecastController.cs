using Domain.Entities;
using Domain.Services.Persons;
using Microsoft.AspNetCore.Mvc;

namespace ApiPresentacion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IPersonService _personService; 

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger , IPersonService personService)
        {
            _personService = personService;

            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<Person>> Get()
        {
            var data = await _personService.GetAllAsync();

            return data;
           
        }
    }
}
