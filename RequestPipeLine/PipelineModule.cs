using System;
using System.Web;

namespace RequestPipeLine
{
    public class PipelineModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.AcquireRequestState += GetEventHandler("AcquireRequestState");           
            context.AuthenticateRequest += GetEventHandler("AuthenticateRequest");
            context.AuthorizeRequest += GetEventHandler("AuthorizeRequest");
            context.BeginRequest += GetEventHandler("BeginRequest");
            context.EndRequest += GetEventHandler("EndRequest");
            context.LogRequest += GetEventHandler("LogRequest");
            context.MapRequestHandler += GetEventHandler("MapRequestHandler");
            context.PostAcquireRequestState += GetEventHandler("PostAcquireRequestState");
            context.PostAuthenticateRequest += GetEventHandler("PostAuthenticateRequest");
            context.PostAuthorizeRequest += GetEventHandler("PostAuthorizeRequest");
            context.PostLogRequest += GetEventHandler("PostLogRequest");
            context.PostMapRequestHandler += GetEventHandler("PostMapRequestHandler");
            context.PostReleaseRequestState += GetEventHandler("PostReleaseRequestState");
            context.PostRequestHandlerExecute += GetEventHandler("PostRequestHandlerExecute");
            context.PostResolveRequestCache += GetEventHandler("PostResolveRequestCache");
            context.PostUpdateRequestCache += GetEventHandler("PostUpdateRequestCache");
            context.PreRequestHandlerExecute += GetEventHandler("PreRequestHandlerExecute");
            context.PreSendRequestContent += GetEventHandler("PreSendRequestContent");
            context.PreSendRequestHeaders += GetEventHandler("PreSendRequestHeaders");
            context.ReleaseRequestState += GetEventHandler("ReleaseRequestState");
            context.RequestCompleted += GetEventHandler("RequestCompleted");
            context.ResolveRequestCache += GetEventHandler("ResolveRequestCache");
            context.UpdateRequestCache += GetEventHandler("UpdateRequestCache");
        }

        #endregion     

        private EventHandler GetEventHandler(string eventName)
        {
            return (object source, EventArgs e) =>
            {
                if (HttpContext.Current.Request.Url.PathAndQuery.Contains("/Pipeline"))
                {
                    HttpContext.Current.Response.Write(String.Format("<div style='margin-left:100px;margin-top:30px'>{0}</div>", eventName));
                }
            };
        } 
    }
}
