
public interface IDiscountHelper {
    decimal ApplyDiscount(decimal totalParam);
}

public class DefaultDiscountHelper : IDiscountHelper {
    private decimal discountRate;

    public DefaultDiscountHelper(decimal discountParam) {
        discountRate = discountParam;
    }

    public decimal ApplyDiscount(decimal totalParam) {
        return (totalParam - (discountRate/ 100m * totalParam));
    }
}
