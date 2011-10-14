using System.Collections.Generic;
using NinjectDemo.Models.Abstract;
using NinjectDemo.Models.Entities;

namespace NinjectDemo.Models.Concrete {

    public class FakeProductRepository : IProductRepository {

        public IEnumerable<Product> GetProducts() {
            return new[] {
                new Product() { Name = "Kayak", Price = 275M},
                new Product() { Name = "Lifejacket", Price = 48.95M},
                new Product() { Name = "Soccer ball", Price = 19.50M},
                new Product() { Name = "Stadium", Price = 79500M}
            };   
        }
    }
}