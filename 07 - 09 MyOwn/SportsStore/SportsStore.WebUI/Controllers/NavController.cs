using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;

            return PartialView(repository.Products
                                         .Select(p => p.Category)
                                         .Distinct()
                                         .OrderBy(p => p));
        }
    }
}
