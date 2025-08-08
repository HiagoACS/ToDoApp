using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using System.Web;

    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var response = new
            {
                Message = "An unexpected error occurred. Please try again later.",
                Detail = context.Exception.Message
            };
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, response);
        }
    }