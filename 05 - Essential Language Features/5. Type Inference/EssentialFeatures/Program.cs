
class Program {
    static void Main(string[] args) {

        // these statements are here so that we can generate
        // results that display US currency values even though
        // the locale of our machines is set to the UK
        System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");
        System.Threading.Thread.CurrentThread.CurrentCulture = ci;
        System.Threading.Thread.CurrentThread.CurrentUICulture = ci;

        
        var myVariable = new Product { Name = "Kayak", Category = "Watersports", Price = 275M };

        string name = myVariable.Name;  // legal
        int count = myVariable.Count;   // compiler error

    }
}
