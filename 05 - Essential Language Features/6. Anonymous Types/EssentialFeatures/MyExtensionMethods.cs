using System.Collections.Generic;
using System;

public static class MyExtensionMethods {

    public static decimal TotalPrices(this IEnumerable<Product> productEnum) {
        decimal total = 0;
        foreach (Product prod in productEnum) {
            total += prod.Price;
        }
        return total;
    }

public static IEnumerable<Product> Filter(
        this IEnumerable<Product> productEnum, 
        Func<Product, bool> selectorParam) {

    foreach (Product prod in productEnum) {
        if (selectorParam(prod)) {
            yield return prod;
        }
    }
}
}
