using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UtopiaCity.Models.Common;

namespace UtopiaCity.ViewComponents
{
    [ViewComponent(Name = "LoggedIn")]
    public class LoggedInViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string loginData;
            if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
            {
                loginData = $"Logged in as: {HttpContext.User.Identity.Name}";
            }
            else
            {
                loginData = "You are not logged in!";
            }

            var model = new StringDataModel() { Data = loginData };
            return View("LoggedInView", model);
        }
    }
}
