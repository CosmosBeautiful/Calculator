using Calculator.Controller;
using Calculator.Functional;
using Calculator.Functional.Arithmetic;
using Calculator.Repositories;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            //Poor Man's DI
            IValidationEquation validationRepository = new ArithmeticValidationEquation();
            ISeparationEquation separationEquation = new ArithmeticSeparationEquation();
            ICalculationEquation calculationEquation = new ArithmeticCalculationEquation();

            IInputRepository inputRepository = new InputRepository(validationRepository);
            IPrintRepository printRepository = new PrintRepository();
            ICalculatorRepository calculatorRepository = new CalculatorRepository(separationEquation, calculationEquation);

            CalculatorController calculator = new CalculatorController(inputRepository, printRepository, calculatorRepository);

            calculator.SolveEquation();
        }
    }
}
