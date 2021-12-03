using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Business;

namespace UtopiaCity.Controllers.Business
{
    public class BusinessController : Controller
    {
        private readonly IBusinessService _businessService;

        public BusinessController(IBusinessService businessService)
        {
            _businessService = businessService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var indexViewModel = await _businessService.CreateIndexViewModel();
            return View(indexViewModel);
        }
    }
}
