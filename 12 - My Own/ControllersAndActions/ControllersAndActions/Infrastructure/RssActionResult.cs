using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ControllersAndActions.Infrastructure
{
    public abstract class RssActionResult : ActionResult
    {
    }

    public class RssActionResult<T> : RssActionResult
    {
        public RssActionResult(string title, IEnumerable<T> dataItems, Func<T, XElement> formatter)
        {
            Title = title;
            DataItems = dataItems;
            Formatter = formatter;
        }

        public string Title { get; set; }
        public IEnumerable<T> DataItems { get; set; }
        public Func<T, XElement> Formatter { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = "application/rss+xml";
            response.Write(generateXml(response.ContentEncoding.WebName));
        }

        private string generateXml(string encoding)
        {
            XDocument rss = new XDocument(
                new XDeclaration("1.0", encoding, "yes"),
                new XElement(
                    "rss",
                    new XAttribute("version", "2.0"),
                    new XElement(
                        "channel",
                        new XElement("title", Title),
                        DataItems.Select(i => Formatter(i))
                    )
                )
            );

            return rss.ToString();
        }
    }
}