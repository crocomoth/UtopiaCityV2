using Microsoft.AspNetCore.Mvc;
using System;
using UtopiaCity.Common.Extensions;

namespace UtopiaCity.Controllers
{
    public abstract class BaseController : Controller
    {
        protected ActionResult TryExecuteActionResult(Func<ActionResult> func)
        {
            try
            {
                return func.Invoke();
            }
            catch (Exception e)
            {
                return this.ViewError(e);
            }
        }
    }
}
