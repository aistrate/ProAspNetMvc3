using System.Web.Mvc;
using System;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using ControllersAndActions.Infrastructure;

namespace ControllersAndActions.Controllers {

    public class ExampleController : Controller {

        public ContentResult Index() {
            string message = "This is plain text";
            return Content(message, "text/plain", Encoding.Default);
        }


        public RedirectToRouteResult Redirect() {
            return RedirectToRoute(new {
                controller = "Example",
                action = "Index",
                ID = "MyID"
            });
        }



        public HttpStatusCodeResult StatusCode() {
            return HttpNotFound();
        }

        public FileResult AnnualReport() {

            string filename = @"c:\AnnualReport.pdf";
            string contentType = "application/pdf";
            string downloadName = "AnnualReport2011.pdf";

            return File(filename, contentType, downloadName);
        }

        public JavaScriptResult SayHello() {
            return JavaScript("alert('Hello, world!')");
        }

        public RssActionResult RSS() {

            StoryLink[] stories = GetAllStories();
            return new RssActionResult<StoryLink>("My Stories", stories, e => {
                return new XElement("item",
                    new XAttribute("title", e.Title),
                    new XAttribute("description", e.Description),
                    new XAttribute("link", e.Url));
            });
        }




        [HttpPost]
        public JsonResult JsonData() {

            StoryLink[] stories = GetAllStories();
            return Json(stories);
        }


        private StoryLink[] GetAllStories() {
            return new StoryLink[] {
                new StoryLink {
                    Title = "First example story",
                    Description = "This is the first example story",
                    Url = "/Story/1"},
                new StoryLink {
                    Title = "Second example story",
                    Description = "This is the second example story",
                    Url = "/Story/2"},
                new StoryLink {
                    Title = "Third example story",
                    Description = "This is the third example story",
                    Url = "/Story/3"},
            };
        }


    }

    public class StoryLink {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }

}