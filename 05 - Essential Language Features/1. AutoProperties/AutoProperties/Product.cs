public class Product {
    private string name;

    public int ProductID { get; set; }

    public string Name {
        get { return ProductID + name;}
        set { name = ProductID + value; }
    }

    public string Description { get; set;}
    public decimal Price { get; set; }
    public string Category { set; get;}
}