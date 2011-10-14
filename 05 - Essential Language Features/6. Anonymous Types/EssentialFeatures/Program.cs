
using System;
class Program {
    static void Main(string[] args) {

        var oddsAndEnds = new[] {
            new { Name = "MVC", Category = "Pattern"},
            new { Name = "Hat", Category = "Clothing"},
            new { Name = "Apple", Category = "Fruit"}
        };

        foreach (var item in oddsAndEnds) {
            Console.WriteLine("Name: {0}", item.Name);            
        }
    }
}
