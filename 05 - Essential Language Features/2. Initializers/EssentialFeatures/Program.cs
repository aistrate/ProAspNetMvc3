using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {

        // create a new Product object
        ProcessProduct(new Product() {
            ProductID = 100, Name = "Kayak",
            Description = "A boat for one person",
            Price = 275M, Category = "Watersports"
        });

        //Console.WriteLine(5 + "abc");

        List<int> intList = new List<int> { 10, 20, 30, 40 };
        Console.WriteLine(intList[1]);
    }

    private static void ProcessProduct(Product prodParam) {
        //...statements to process product in some way
        Console.WriteLine(prodParam.Name);
    }
}
