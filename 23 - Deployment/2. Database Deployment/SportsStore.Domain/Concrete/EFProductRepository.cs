using System.Linq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete.ORM;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete {

    public class EFProductRepository : IProductRepository {
        private EFContext context;

        public EFProductRepository() {
            context = new EFContext();
        }

        public IQueryable<Product> Products {
            get { return context.Products; }
        }


        public void SaveProduct(Product product) {

            if (product.ProductID == 0) {
                context.Products.AddObject(product);
            } else {
                context.Products.Attach(new Product { ProductID = product.ProductID });
                context.Products.ApplyCurrentValues(product);
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product) {
            context.Products.DeleteObject(product);
            context.SaveChanges();
        }
    }
}