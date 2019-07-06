using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http;

namespace Services.Controllers
{
    public class ValidateMimeMultipartContentFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.ContentType != "mime")
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            //
        }

    }
}
