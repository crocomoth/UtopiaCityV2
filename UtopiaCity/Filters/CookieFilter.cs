using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace UtopiaCity.Filters
{
    public class CookieFilter : Attribute, IResourceFilter
    {
        private readonly string _name;
        private readonly string _value;

        public CookieFilter()
        {
        }

        public CookieFilter(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));

            if (!string.IsNullOrWhiteSpace(_name))
            {
                context.HttpContext.Response.Cookies.Append(_name, _value ?? string.Empty);
            }
        }
    }
}
