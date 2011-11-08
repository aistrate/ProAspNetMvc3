using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using DynamicData.Models;

namespace DynamicData.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //new HtmlHelper().ActionLink
            //new AjaxExtensions
            //new AjaxHelper().ActionLink
            return View();
        }

        public ActionResult Typed()
        {
            return View((object)"Some string");
        }

        public ActionResult InlineHelper()
        {
            ViewBag.Fruits = new[] { "Apple", "Mango", "Banana" };
            return View();
        }

        public ActionResult InlineHelper2()
        {
            return View();
        }

        public ActionResult ExternalHelper()
        {
            ViewBag.Fruits = new[] { "Apple", "Pear", "Orange" };
            return View();
        }

        public ActionResult BuiltInHelpers()
        {
            return View(new Order { IsApproved = true, Status = OrderStatus.Approved });
        }

        [HttpPost]
        public ActionResult BuiltInHelpers(Order order)
        {
            return View(order);
        }

        public ActionResult Region()
        {
            ViewData["region"] = new SelectList(
                new[]
                {
                    new Region { RegionId = 7, RegionName = "Northern" },
                    new Region { RegionId = 3, RegionName = "Central" },
                    new Region { RegionId = 5, RegionName = "Southern" },
                },
                "RegionId",
                "RegionName",
                3);

            return View();
        }

        public ActionResult Grid()
        {
            var products = new[]
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275m},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95m},
                new Product {Name = "Soccer ball", Category = "Football", Price = 19.50m},
                new Product {Name = "Corner flags", Category = "Football", Price = 34.95m},
                new Product {Name = "Stadium", Category = "Football", Price = 79500m},
                new Product {Name = "Thinking cap", Category = "Chess", Price = 16m},
            };

            return View(products);
        }

        public ActionResult Grid2()
        {
            var products = new[]
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275m},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95m},
                new Product {Name = "Soccer ball", Category = "Football", Price = 19.50m},
                new Product {Name = "Corner flags", Category = "Football", Price = 34.95m},
                new Product {Name = "Stadium", Category = "Football", Price = 79500m},
                new Product {Name = "Thinking cap", Category = "Chess", Price = 16m},
            };

            ViewBag.WebGrid = new WebGrid(source: products, rowsPerPage: 3);

            return View(products);
        }

        public void ChartImage()
        {
            var products = new[]
            {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275m},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95m},
                new Product {Name = "Soccer ball", Category = "Football", Price = 19.50m},
                new Product {Name = "Corner flags", Category = "Football", Price = 34.95m},
                new Product {Name = "Thinking cap", Category = "Chess", Price = 16m},
            };

            Chart chart = new Chart(600, 200,
                                    @"<Chart BackColor=""Gray"" BackSecondaryColor=""WhiteSmoke""
BackGradientStyle=""DiagonalRight"" AntiAliasing=""All""
BorderlineDashStyle = ""Solid"" BorderlineColor = ""Gray"">
<BorderSkin SkinStyle = ""Emboss"" />
<ChartAreas>
<ChartArea Name=""Default"" _Template_=""All"" BackColor=""Wheat""
BackSecondaryColor=""White"" BorderColor=""64, 64, 64, 64""
BorderDashStyle=""Solid"" ShadowColor=""Transparent"">
</ChartArea>
</ChartAreas>
</Chart>");

            chart.AddSeries(
                chartType: "Column",
                yValues: products.Select(p => p.Price).ToArray(),
                xValue: products.Select(p => p.Name).ToArray()
            );

            chart.Write();
        }

        public ActionResult OtherHelpers()
        {
            return View();
        }
    }
}
