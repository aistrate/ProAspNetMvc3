using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using System.Web;

namespace SportsStore.WebUI.Controllers {

    [Authorize]
    public class AdminController : Controller {
        private IProductRepository repository;

        public AdminController(IProductRepository repo) {
            repository = repo;
        }

        public ViewResult Index() {
            return View(repository.Products);
        }

        public ViewResult Create() {
            return View("Edit", new Product());
        }

        public ViewResult Edit(int productId) {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int productId) {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null) {
                repository.DeleteProduct(prod);
                TempData["message"] = string.Format("{0} was deleted", prod.Name);
            } 
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image) {

            if (ModelState.IsValid) {
                if (image != null) {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                // save the product
                repository.SaveProduct(product);
                // add a message to the viewbag
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                // return the user to the list
                return RedirectToAction("Index");
            } else {
                // there is something wrong with the data values
                return View(product);
            }
        }
    }
}
