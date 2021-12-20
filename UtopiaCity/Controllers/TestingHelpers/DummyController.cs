using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.TestingHelpers
{
    public class DummyController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
