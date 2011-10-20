using System;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web.Mvc;
using System.Xml.Linq;
using ControllersAndActions.Models;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers
{
    public class ExampleController : Controller
    {
        public ViewResult Index()
        {
            //ViewDataDictionary vdd = new ViewDataDictionary(DateTime.Now);

            return View(DateTime.Now);
        }

        public ViewResult Hello()
        {
            return View((object)"Hello, world");
        }

        public RedirectResult Redirect()
        {
            return Redirect("/Example/Index");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new
            {
                controller = "Example",
                action = "Index",
                id = "MyID",
            });

            //return RedirectToRoute(new RouteValueDictionary
            //{
            //    { "controller", "Example" },
            //    { "action", "Index" },
            //    { "id", "MyID" },
            //});
        }

        public ViewResult RedirectTarget()
        {
            DateTime date = TempData["Date"] != null ? (DateTime)TempData["Date"] : DateTime.Now;

            return View("Index", date);
        }

        public RedirectToRouteResult RedirectSource()
        {
            TempData["Date"] = DateTime.Now.AddDays(-1);

            return RedirectToAction("RedirectTarget");
        }

        public ContentResult TextData()
        {
            string message = "This is plain text";

            //return Content(message, "text/plain", Encoding.Default);
            //return Content(message, "text/plain");
            return Content(message, MediaTypeNames.Text.Plain);
        }

        public object TextData2()
        {
            return "This is plain text";
        }

        public string TextData3()
        {
            return "This is plain text";
        }

        public ContentResult XmlData()
        {
            Story[] stories = getStories();

            XElement root = new XElement(
                "StoryList",
                stories.Select(s => new XElement(
                    "Story",
                    new XAttribute("title", s.Title),
                    new XAttribute("desc", s.Description),
                    new XAttribute("url", s.Url))));

            return Content(root.ToString(), "text/xml");
        }

        public JsonResult JsonData()
        {
            return Json(getStories(), JsonRequestBehavior.AllowGet);
        }

        private Story[] getStories()
        {
            return new Story[]
            {
                new Story { Title = "First story", Description = "This is the first story", Url = "/Story/1" },
                new Story { Title = "Second story", Description = "This is the second story", Url = "/Story/2" },
                new Story { Title = "Third story", Description = "This is the third story", Url = "/Story/3" },
            };
        }

        public FilePathResult Book()
        {
            return File(@"C:\Languages\C#\MVC3\Pro ASP.NET MVC 3 Framework (Apress).pdf",
                        MediaTypeNames.Application.Pdf,
                        "ASP.NET MVC3.pdf");
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "URL cannot be serviced");
        }

        public HttpStatusCodeResult NotFound()
        {
            return HttpNotFound();
        }

        public HttpStatusCodeResult Unauthorized()
        {
            return new HttpUnauthorizedResult();
        }

        public RssActionResult Rss()
        {
            return new RssActionResult<Story>(
                "My Stories",
                getStories(),
                s => new XElement(
                            "item",
                            new XElement("title", s.Title),
                            new XElement("description", s.Description),
                            new XElement("link", s.Url)
                     )
            );
        }
    }
}
