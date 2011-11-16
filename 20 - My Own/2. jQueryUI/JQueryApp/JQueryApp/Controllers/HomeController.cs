using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryApp.Models;

namespace JQueryApp.Controllers
{
    public class HomeController : Controller
    {
        private static Summit[] summits = new[]
        {
            new Summit { Name = "Everest", Height = 8848 },
            new Summit { Name = "Aconcagua", Height = 6962 },
            new Summit { Name = "McKinley", Height = 6194 },
            new Summit { Name = "Kilimanjaro", Height = 5895 },
            new Summit { Name = "K2", Height = 8611 },
        };

        public ActionResult Index()
        {
            return View(summits);
        }
    }
}
