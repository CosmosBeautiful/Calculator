using Calculator.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Tests.Repositories.CalculatorRepositoryTests
{
    [TestClass]
    public class CalculatorRepositoryTests
    {

        private ICalculatorRepository calculatorRepository;

        [TestInitialize]
        public void ClassInitialize()
        {
            calculatorRepository = new CalculatorRepository();
        }

        [TestMethod]
        public void SolveEquation()
        {
            // arrange
            //string equation = "42 + 18 / ( 6 + 12 / 4 )";
            //double expectedResult = 44;

            //string equation = "42 + 18 * ( 12 / 6 + 10 - ( 5 * ( 6 + 2 ) ) + 27 ) / ( 6 + 12 / 4 ) + 100 / 20";
            //double expectedResult = 45;

            //string equation = "12 / 6 + 10 - ( 5 * ( 6 + 2 ) ) + 27";
            //double expectedResult = -1;

            //string equation = "( 5 * 2 ) / ( 12 / 6 )";
            //double expectedResult = 5;

            string equation = "( 100 / 5 + 62 * 2 + ( 44 - 22 / 10 ) ) + ( 84 * 56 / ( 12 / 6 ) + 90 - ( 5 * 5 - 1 ) )";
            double expectedResult = 2603.8;

            // act
            double actualResult = calculatorRepository.SolveEquation(equation);

            // assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
