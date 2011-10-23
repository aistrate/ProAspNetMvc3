using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DynamicData.Models;
using System.Web.Helpers;
using DynamicData.Infrastructure;

namespace DynamicData.Controllers {

    public class HomeController : Controller {
    
        public ActionResult Index() {

            string message = "Hello, World";

            return View((object)message);
        }

        public ActionResult InlineHelper() {

            ViewBag.Days = new[] { "Monday", "Tuesday", "Wednesday", "etc" };
            ViewBag.Fruits = new[] { "Apples", "Mango", "Banana" };

            return View();
        }


        public ActionResult ExternalHelper() {

            ViewBag.Days = new[] { "Monday", "Tuesday", "Wednesday", "etc" };
            ViewBag.Fruits = new[] { "Apples", "Mango", "Banana" };

            return View();
        }

        public ActionResult Grid() {

            IEnumerable<Product> productList = new List<Product> {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275m},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95m},
                new Product {Name = "Soccer ball", Category = "Football", Price = 19.50m},
                new Product {Name = "Corner flags", Category = "Football", Price = 34.95m},
                new Product {Name = "Stadium", Category = "Football", Price = 79500m},
                new Product {Name = "Thinking cap", Category = "Chess", Price = 16m}
            };

            ViewBag.WebGrid = new WebGrid(source: productList, rowsPerPage: 4);

            return View(productList);
        }

        public ActionResult EncodedData() {
            return View((object)MyUtility.GetUsefulData());
        }


        public void Chart() {

            IEnumerable<Product> productList = new List<Product> {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275m},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95m},
                new Product {Name = "Soccer ball", Category = "Football", Price = 19.50m},
                new Product {Name = "Corner flags", Category = "Football", Price = 34.95m},
                new Product {Name = "Stadium", Category = "Football", Price = 150m},
                new Product {Name = "Thinking cap", Category = "Chess", Price = 16m}
            };

            Chart chart = new Chart(400, 200,
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
                yValues: productList.Select(e => e.Price).ToArray(),
                xValue: productList.Select(e => e.Name).ToArray()
                );

            chart.Write();
        }

      
    }
}
