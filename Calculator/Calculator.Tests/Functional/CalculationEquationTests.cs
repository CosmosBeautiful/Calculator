using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Functional;
using Calculator.Models;

namespace Calculator.Tests.Functional
{
    [TestClass]
    public class CalculationEquationTests
    {
        [TestMethod]
        public void GetMaxLevelOperation()
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
            LevelType actualLevel = CalculationEquation.GetMaxLevelOperation(elements);

            // assert
            Assert.AreEqual(exectedLevel, actualLevel);
        }

        [TestMethod]
        public void MakeOperation()
        {
            // arrange
            ElementEquation elementsX = new ElementEquation(15, OperatorType.Mul);
            ElementEquation elementsY = new ElementEquation(4);
            OperatorType operatorX = elementsX.Operation.Operator;
            double exected = 60;

            // act
            double actual = CalculationEquation.MakeOperation(elementsX, operatorX, elementsY);

            // assert
            Assert.AreEqual(actual, exected);
        }
    }
}
