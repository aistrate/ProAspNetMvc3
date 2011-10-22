using System.Threading.Tasks;
using System.Web.Mvc;
using SpecialControllers.Models;

namespace SpecialControllers.Controllers
{
    public class RemoteDataAsyncController : AsyncController
    {
        public ActionResult SyncData()
        {
            return View("Data", (object)new RemoteService().GetRemoteData());
        }

        [AsyncTimeout(5000)]
        public void DataAsync()
        {
            AsyncManager.OutstandingOperations.Increment(2);

            Task.Factory.StartNew(() =>
            {
                AsyncManager.Parameters["data"] = new RemoteService().GetRemoteData();
                AsyncManager.OutstandingOperations.Decrement();
            });

            Task.Factory.StartNew(() =>
            {
                AsyncManager.Parameters["data2"] = new RemoteService().GetOtherRemoteData();
                AsyncManager.OutstandingOperations.Decrement();
            });
        }

        public ActionResult DataCompleted(string data, string data2)
        {
            return View((object)(data + "; " + data2));
        }
    }
}
