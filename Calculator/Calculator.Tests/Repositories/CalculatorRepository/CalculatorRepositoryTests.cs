using Calculator.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Calculator.Functional;
using Calculator.Functional.Arithmetic;

namespace Calculator.Tests.Repositories.CalculatorRepositoryTests
{
    [TestClass]
    public class CalculatorRepositoryTests
    {
        private ISeparationEquation separationEquation;
        private ICalculationEquation calculationEquation;
        private ICalculatorRepository calculatorRepository;

        [TestInitialize]
        public void ClassInitialize()
        {
            separationEquation = new ArithmeticSeparationEquation();
            calculationEquation = new ArithmeticCalculationEquation();
            calculatorRepository = new CalculatorRepository(separationEquation, calculationEquation);
        }
        
        [TestMethod]
        public void SolveEquation()
        {
            // arrange
            Dictionary<string, double> equations = new Dictionary<string, double>
            {
                { "42 + 18 / ( 6 + 12 / 4 )", 44},
                { "42 + 18 * ( 12 / 6 + 10 - ( 5 * ( 6 + 2 ) ) + 27 ) / ( 6 + 12 / 4 ) + 100 / 20", 45},
                { "12 / 6 + 10 - ( 5 * ( 6 + 2 ) ) + 27", -1},
                { "( 5 * 2 ) / ( 12 / 6 )", 5},
                { "( 100 / 5 + 62 * 2 + ( 44 - 22 / 10 ) ) + ( 84 * 56 / ( 12 / 6 ) + 90 - ( 5 * 5 - 1 ) )", 2603.8},
                { "17 + 9 / ( 4 - 1 ) * 65", 212},
                { "( 4 - 1 ) * 2", 6}
            };

            foreach (var equation in equations)
            {
                // act
                double actualResult = calculatorRepository.SolveEquation(equation.Key);

                // assert
                Assert.AreEqual(equation.Value, actualResult, $"{equation.Value} != {actualResult}");
            }
        }
    }
}
