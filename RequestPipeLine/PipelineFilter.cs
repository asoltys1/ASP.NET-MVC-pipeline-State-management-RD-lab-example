using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace RequestPipeLine
{
    public class PipelineFilterAttribute : FilterAttribute, IActionFilter, IResultFilter, IAuthorizationFilter, IAuthenticationFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Write("OnActionExecuted");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Write("OnActionExecuting");
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Write("OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Write("OnResultExecuting");
        }       

        public void OnAuthentication(AuthenticationContext filterContext)
        {
            Write("OnAuthentication");
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            Write("OnAuthenticationChallenge");
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            Write("OnAuthorization");
        }       

        private void Write(string stage)
        {
            HttpContext.Current.Response.Write(String.Format("<div style='margin-left:200px;margin-top:30px'>{0}</div>", stage));
        }
    }
}