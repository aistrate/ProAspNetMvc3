using System.Linq;
using System;

public interface IValueCalculator {

    decimal ValueProducts(params Product[] products);
}

public class LinqValueCalculator : IValueCalculator {
    private IDiscountHelper discounter;

    public LinqValueCalculator(IDiscountHelper discountParam) {
        discounter = discountParam;
    }

    public decimal ValueProducts(params Product[] products) {
        return discounter.ApplyDiscount(products.Sum(p => p.Price));
    }
}

public class IterativeValueCalculator : IValueCalculator {

    public decimal ValueProducts(params Product[] products) {
        Console.WriteLine("Here");
        decimal totalValue = 0;
        foreach (Product p in products) {
            totalValue += p.Price;
        }
        return totalValue;
    }
}