using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Services.Business;
using UtopiaCity.ViewModels.Business.Position;

namespace UtopiaCity.Controllers.Business
{
    public class PositionController: BaseController
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        [HttpGet]
        public async Task<IActionResult> CreatePosition(string companyId)
        {
            var createPositionViewModel = new CreatePositionViewModel(companyId);
            return View("Views/Business/Position/CreatePosition.cshtml", createPositionViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePosition(CreatePositionViewModel CreatePositionViewModel)
        {
            await _positionService.CreatePosition(CreatePositionViewModel);
            return RedirectToAction("Index", "Business");
        }
    }
}
