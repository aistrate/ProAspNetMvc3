using Views.Models;

namespace Views.Infrastructure
{
    public class SimpleCalculator : ICalculator
    {
        public int Product(int x, int y)
        {
            return x * y;
        }
    }
}