using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NinjectDemo.Models.Abstract;

namespace NinjectDemo.Controllers {

    public class ProductController : Controller {
        private IProductRepository repository;

        public ProductController(IProductRepository repoParam) {
            repository = repoParam;                
        }

        public ViewResult Index() {
            // return the products from the repository
            return View(repository.GetProducts());
        }
    }
}
