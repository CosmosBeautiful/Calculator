using Calculator.Functional.Arithmetic;
using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests.Functional
{
    [TestClass]
    public class ArithmeticCalculationEquationTests
    {
        private ArithmeticCalculationEquation arithmeticCalculation;

        [TestInitialize]
        public void ClassInitialize()
        {
            arithmeticCalculation = new ArithmeticCalculationEquation();
        }

        [TestMethod]
        public void GetMaxLevelOperation_ElementsEquation_ReturnHighLevel()
        {
            // arrange
            List<ElementEquation> elements = new List<ElementEquation>
            {
                new ElementEquation(55, OperatorType.Sum),
                new ElementEquation(47, OperatorType.Brackets),
                new ElementEquation(10, OperatorType.Del)
            };
            LevelType exectedLevel = LevelType.High;

            // act
            LevelType actualLevel = arithmeticCalculation.GetMaxLevelOperation(elements);

            // assert
            Assert.AreEqual(exectedLevel, actualLevel);
        }

        [TestMethod]
        public void MakeOperation_15Mul4_Return60()
        {
            // arrange
            ElementEquation elementsX = new ElementEquation(15, OperatorType.Mul);
            ElementEquation elementsY = new ElementEquation(4);
            OperatorType operatorX = elementsX.Operation.Operator;
            double exected = 60;

            // act
            double actual = arithmeticCalculation.MakeOperation(elementsX, operatorX, elementsY);

            // assert
            Assert.AreEqual(actual, exected);
        }
    }
}
