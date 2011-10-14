using System.Linq;
using Ninject;
using System;


class Program {
    static void Main(string[] args) {

        // these statements are here so that we can generate
        // results that display US currency values even though
        // the locale of our machines is set to the UK
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

        IKernel ninjectKernel = new StandardKernel();

        ninjectKernel.Bind<IValueCalculator>().To(typeof(LinqValueCalculator));
        ninjectKernel.Bind<IDiscountHelper>()
            .To(typeof(DefaultDiscountHelper)).WithConstructorArgument("discountParam", 50M);

        // get the interface implementation
        IValueCalculator calcImpl = ninjectKernel.Get<IValueCalculator>();
        // create the instance of ShoppingCart and inject the dependency
        ShoppingCart cart = new ShoppingCart(calcImpl);
        // perform the calculation and write out the result
        Console.WriteLine("Total: {0:c}", cart.CalculateStockValue());
    }
}

public class Product {

    public int ProductID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { set; get; }

}

public class ShoppingCart {
    private IValueCalculator calculator;

    public ShoppingCart(IValueCalculator calcParam) {
        calculator = calcParam;
    }

    public decimal CalculateStockValue() {
        // define the set of products to sum
        Product[] products = {
            new Product() { Name = "Kayak", Price = 275M},
            new Product() { Name = "Lifejacket", Price = 48.95M},
            new Product() { Name = "Soccer ball", Price = 19.50M},
            new Product() { Name = "Stadium", Price = 79500M}
        };

        // calculate the total value of the products
        decimal totalValue = calculator.ValueProducts(products);

        // return the result
        return totalValue;
    }
}
