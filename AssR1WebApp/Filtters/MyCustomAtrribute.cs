using Microsoft.AspNetCore.Mvc.Filters;

namespace AssR1WebApp.Filtters
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        //Common code
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //loigc
            //context.
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //locic
            //context.RouteData
        }
    }
}
