using Calculator.DI;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            CreatorCalculator creatorCalculators = new ConcreteArithmeticCalculator();
            ICalculator calculator = creatorCalculators.FactoryMethod();

            calculator.SolveEquation();
        }
    }
}
