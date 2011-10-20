using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ControllersAndActions.Infrastructure {

    public abstract class RssActionResult : ActionResult {

    }

    public class RssActionResult<T> : RssActionResult {

        public RssActionResult(string title, IEnumerable<T> data, 
            Func<T, XElement> formatter) {

            Title = title;
            DataItems = data;
            Formatter = formatter;
        }

        public IEnumerable<T> DataItems { get; set; }
        public Func<T, XElement> Formatter { get; set; }
        public string Title { get; set; }

        public override void ExecuteResult(ControllerContext context) {

            HttpResponseBase response = context.HttpContext.Response;

            // set the content type of the response
            response.ContentType = "application/rss+xml";
            // get the RSS content
            string rss = GenerateXML(response.ContentEncoding.WebName);
            // write the content to the client
            response.Write(rss);   
        }

        private string GenerateXML(string encoding) {
            
             XDocument rss = new XDocument(new XDeclaration("1.0", encoding, "yes"), 
                new XElement("rss", new XAttribute("version", "2.0"), 
                    new XElement("channel", new XElement("title", Title), 
                        DataItems.Select(e => Formatter(e)))));

             return rss.ToString();
        }
    }
}