using Microsoft.AspNetCore.Mvc;

namespace UtopiaCity.Controllers.Emergency
{
    public class EmergencyReportTestController : BaseController
    {
        public IActionResult Index()
        {
            return View("TestView");
        }

        [HttpPost]
        public ActionResult SomeAction()
        {
            return Ok("From server");
        }
    }
}
