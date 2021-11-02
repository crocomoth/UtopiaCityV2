using Microsoft.AspNetCore.Mvc;
using System;
using UtopiaCity.Models;

namespace UtopiaCity.Common.Extensions
{
    public static class ControllerExtensions
    {
        public static ViewResult ViewError(this Controller controller, Exception exception)
        {
            return controller.View("Error", new ErrorViewModel() { Data = exception.Message });
        }
    }
}
