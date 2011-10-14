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

        ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        ninjectKernel.Bind<IValueCalculator>()
            .To<IterativeValueCalculator>()
            .WhenInjectedInto<LimitShoppingCart>();

        ninjectKernel.Bind<IDiscountHelper>()
            .To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 50M);

        ninjectKernel.Bind<ShoppingCart>()
            .To<LimitShoppingCart>()
            .WithPropertyValue("ItemLimit", 200M);

        // get an instance of the ShoopingCart class
        ShoppingCart cart = ninjectKernel.Get<ShoppingCart>();
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
    protected IValueCalculator calculator;
    protected Product[] products;

    public ShoppingCart(IValueCalculator calcParam) {
        calculator = calcParam;

        // define the set of products to sum
        products = new[] {
            new Product() { Name = "Kayak", Price = 275M},
            new Product() { Name = "Lifejacket", Price = 48.95M},
            new Product() { Name = "Soccer ball", Price = 19.50M},
            new Product() { Name = "Stadium", Price = 79500M}
        };
    }

    public virtual decimal CalculateStockValue() {
        
        // calculate the total value of the products
        decimal totalValue = calculator.ValueProducts(products);

        // return the result
        return totalValue;
    }
}

public class LimitShoppingCart : ShoppingCart {

    public LimitShoppingCart(IValueCalculator calcParam)
        : base(calcParam) {
        // nothing to do here
    }

    public override decimal CalculateStockValue() {
        // filter out any items that are over the limit
        var filteredProducts = products
            .Where(e => e.Price < ItemLimit)
            .Select(e => e);
        // perform the calculation
        return calculator.ValueProducts(filteredProducts.ToArray());
    }

    public decimal ItemLimit { get; set; }
}
