using System.Data.Objects;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete.ORM {

    public class EFContext : ObjectContext {
        private ObjectSet<Product> products;

        public EFContext()
            : base("name=SportsStoreEntities", "SportsStoreEntities") {

            products = CreateObjectSet<Product>();
        }

        public ObjectSet<Product> Products {
            get {
                return products;
            }
        }
    }
}
