using _03DependencyInversion.Interfaces;
using _03DependencyInversion.Models.Strategies;

namespace _03DependencyInversion.Models
{
    public class PrimitiveCalculator
    {
        private ICalculationStrategy strategy;

        public PrimitiveCalculator(ICalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public PrimitiveCalculator()
        {
            this.strategy = new AdditionStrategy();
        }

        public void ChangeStrategy(ICalculationStrategy strategy)
        {
            this.strategy = strategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.strategy.Calculate(firstOperand, secondOperand);
        }
    }
}
