using Calculator.Repositories;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests.Repositories.CalculatorRepositoryTests
{
    [TestClass]
    public class CalculatorRepositoryTests
    {
        //public TestContext TestContextInstance { get; set; }
        private ICalculatorRepository calculatorRepository;

        [TestInitialize]
        public void ClassInitialize()
        {
            calculatorRepository = new CalculatorRepository();
        }

        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|/testDataEquation.xml", "Equation", DataAccessMethod.Sequential)]
        [TestMethod]
        public void SolveEquation()
        {
            // arrange
            //string equation = Convert.ToString(TestContextInstance.DataRow["equation"]);

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
