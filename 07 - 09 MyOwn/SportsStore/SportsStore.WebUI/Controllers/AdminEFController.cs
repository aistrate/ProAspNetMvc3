using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{ 
    public class AdminEFController : Controller
    {
        //private Product_ db = new Product_();
        private EFDbContext db = new EFDbContext();

        //
        // GET: /AdminEF/

        public ViewResult Index()
        {
            return View(db.Products.ToList());
        }

        //
        // GET: /AdminEF/Details/5

        public ViewResult Details(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // GET: /AdminEF/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /AdminEF/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /AdminEF/Edit/5
 
        public ActionResult Edit(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /AdminEF/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        //
        // GET: /AdminEF/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            return View(product);
        }

        //
        // POST: /AdminEF/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}