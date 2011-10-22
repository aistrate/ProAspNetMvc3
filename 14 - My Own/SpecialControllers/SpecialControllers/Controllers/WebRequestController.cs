using System.IO;
using System.Net;
using System.Web.Mvc;

namespace SpecialControllers.Controllers
{
    public class WebRequestController : AsyncController
    {
        public ActionResult NormalPage()
        {
            WebRequest webRequest = WebRequest.Create("http://www.asp.net");

            WebResponse webResponse = webRequest.GetResponse();
            string html = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

            return Content(html, "text/html");
        }

        public void PageAsync()
        {
            AsyncManager.OutstandingOperations.Increment();

            WebRequest webRequest = WebRequest.Create("http://www.amazon.com");

            webRequest.BeginGetResponse(ias =>
                {
                    WebResponse webResponse = webRequest.EndGetResponse(ias);
                    string html = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

                    AsyncManager.Parameters["html"] = html;
                    AsyncManager.OutstandingOperations.Decrement();
                },
                null);
        }

        public ActionResult PageCompleted(string html)
        {
            return Content(html, "text/html");
        }
    }
}
