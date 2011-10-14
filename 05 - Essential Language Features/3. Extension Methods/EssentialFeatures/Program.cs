using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {

        // these statements are here so that we can generate
        // results that display US currency values even though
        // the locale of our machines is set to the UK
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

        // create and populate ShoppingCart 
        IEnumerable<Product> products = new ShoppingCart {
            Products = new List<Product> {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            }
        };

        //// create and populate an array of Product objects
        //Product[] productArray = {
        //    new Product {Name = "Kayak", Price = 275M},
        //    new Product {Name = "Lifejacket", Price = 48.95M},
        //    new Product {Name = "Soccer ball", Price = 19.50M},
        //    new Product {Name = "Corner flag", Price = 34.95M}
        //};

        decimal total = products.FilterByCategory("Soccer").TotalPrices();
        Console.WriteLine("Filtered total: {0:c}", total);


        // get the total value of the products in the cart
        //decimal cartTotal = products.TotalPrices();
        //decimal arrayTotal = products.TotalPrices();

        //Console.WriteLine("Cart Total: {0:c}", cartTotal);
        //Console.WriteLine("Array Total: {0:c}", arrayTotal);
        
    }
}
