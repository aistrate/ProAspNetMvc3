using System;
using System.Web.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            Product product = new Product
            {
                ProductID = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "Watersports",
                Price = 275m,
            };

            ViewBag.ProcessingTime = DateTime.Now.ToLongTimeString();

            return View(product);
        }
    }
}
