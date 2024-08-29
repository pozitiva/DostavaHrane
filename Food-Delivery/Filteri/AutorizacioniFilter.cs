using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DostavaHrane.Filteri
{
    public class AutorizacioniFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var authHeader = context.HttpContext.Request.Headers["Authorization"].ToString();

            if (string.IsNullOrEmpty(authHeader) || !IsAuthorized(authHeader))
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                context.HttpContext.Items["Authorization"] = authHeader;
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Ova metoda se može koristiti za logiku posle izvršenja akcije
        }

        private bool IsAuthorized(string authHeader)
        {
            // Logika za autorizaciju
            return true; // Promeni ovo u stvarnu logiku autorizacije
        }
    }

}
