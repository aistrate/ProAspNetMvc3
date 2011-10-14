using System.Linq;

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