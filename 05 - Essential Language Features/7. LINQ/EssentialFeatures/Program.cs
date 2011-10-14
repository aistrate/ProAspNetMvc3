using System;
using System.Linq;

class Program {
    static void Main(string[] args) {

        Product[] products = {            
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };


 

        var results = products
                        .OrderByDescending(e => e.Price)
                        .Take(3)
                        .Select(e => new { e.Name, e.Price });

        foreach (var p in results) {
            Console.WriteLine("Item: {0}, Cost: {1}", p.Name, p.Price);
        }
        Console.WriteLine("---End of results---");

        products[2] = new Product { Name = "Stadium", Price = 79500M };
        
        foreach (var p in results) {
            Console.WriteLine("Item: {0}, Cost: {1}", p.Name, p.Price);
        }
        Console.WriteLine("---End of results---");
    }
}
