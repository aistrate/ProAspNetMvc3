using Views.Models;

namespace Views.Infrastructure {
    public class SimpleCalculator : ICalculator {
        public int Sum(int x, int y) {
            return x + y;
        }
    }
}