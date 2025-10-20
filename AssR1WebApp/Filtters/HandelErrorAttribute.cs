using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssR1WebApp.Filtters
{
    public class HandelErrorAttribute :Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult
            ViewResult result = new ViewResult();
            result.ViewName = "Error";//Share
            context.Result =  result;//response
            
        }
    }
}
