using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using SpecialControllers.Models;

namespace SpecialControllers.Controllers {

    public class RemoteDataController : AsyncController {

        [AsyncTimeout(1000)]
        public void DataAsync() {

            AsyncManager.OutstandingOperations.Increment();

            Task.Factory.StartNew(() => {
                // create the model object
                RemoteService service = new RemoteService();
                // call the IO-bound, time-consuming function
                string data = service.GetRemoteData();

                AsyncManager.Parameters["data"] = data;
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public ActionResult DataCompleted(string data) {
            return View((object)data);
        }

        public void PageAsync() {

            AsyncManager.OutstandingOperations.Increment();

            WebRequest req = WebRequest.Create("http://www.asp.net");
            req.BeginGetResponse((IAsyncResult ias) => {
                WebResponse resp = req.EndGetResponse(ias);

                string content = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                AsyncManager.Parameters["html"] = content;
                AsyncManager.OutstandingOperations.Decrement();

            }, null);
        }

        public ContentResult PageCompleted(string html) {

            return Content(html, "text/html");
        }



    }
}
