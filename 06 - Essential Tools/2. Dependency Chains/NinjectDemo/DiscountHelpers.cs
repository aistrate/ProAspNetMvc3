
public interface IDiscountHelper {
    decimal ApplyDiscount(decimal totalParam);
}

public class DefaultDiscountHelper : IDiscountHelper {

    public decimal ApplyDiscount(decimal totalParam) {
        return (totalParam - (10m / 100m * totalParam));
    }
}
