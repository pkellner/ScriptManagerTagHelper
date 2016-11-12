using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ScriptManagerTagHelper.WebSample
{

    public class KeywordStream : MemoryStream
    {
        private readonly Stream responseStream;

        public KeywordStream(Stream stream)
        {
            responseStream = stream;
        }

        public override void Write(byte[] buffer,
        int offset, int count)
        {
            string html = Encoding.UTF8.GetString(buffer);
            html = html.Replace("USA",
                   "<span class='keyword'>USA</span>");
            buffer = Encoding.UTF8.GetBytes(html);
            responseStream.Write(buffer, offset, buffer.Length);
        }

    }

    /// <summary>
    /// http://www.infragistics.com/community/blogs/dhananjay_kumar/archive/2016/03/04/how-to-create-a-custom-action-filter-in-asp-net-mvc.aspx
    /// </summary>
    public class PostRazorResultFilter : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //HttpRequest request = filterContext.HttpContext.Request;

            //request.Body = new MemoryStream(new byte[] {49, 50, 51});

            //var stream = filterContext.HttpContext.Response.fi;
            //string response = new StreamReader(stream).ReadToEnd();
            //ContentResult contres = new ContentResult();
            //contres.Content = response;
            //filterContext.Result = contres;

            //var x = filterContext.Result.ToString();

            //You may fetch data from database here 




            // http://zablo.net/blog/post/asp-net-core-redis-html-cache
            //var httpResponse = filterContext.HttpContext.Response;
            //var responseStream = httpResponse.Body;
            //using (var streamReader = new StreamReader(responseStream, Encoding.UTF8, true, 512, true))
            //{
            //    var toCache = streamReader.ReadToEnd();
            //    var contentType = httpResponse.ContentType;


            //}


            base.OnResultExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", "onactionexecuting", controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");

           




            //http://www.binaryintellect.net/articles/133da380-b62b-4384-a99f-b1b2e105776e.aspx
            //var originalFilter =
            //filterContext.HttpContext.Response.Filter;
            //filterContext.HttpContext.Response.Filter =
            //new KeywordStream(originalFilter);






            base.OnActionExecuting(filterContext);
        }
    }
}

