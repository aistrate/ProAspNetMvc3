using System.Collections.Generic;
using NinjectDemo.Models.Entities;

namespace NinjectDemo.Models.Abstract {

    public interface IProductRepository {

        IEnumerable<Product> GetProducts();
    }
}