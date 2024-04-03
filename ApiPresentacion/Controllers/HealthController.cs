using Microsoft.AspNetCore.Mvc;

namespace ApiPresentacion.Controllers
{
    public class healthController : Controller
    {

        [HttpGet]
        [Route("CheckHealth")]
        public async Task<IActionResult> Get()
        {
            var result = new
            {
                apiVersion = "1.0",
                status = "ok"
            };

            return Ok(result);
        }
    }
}
