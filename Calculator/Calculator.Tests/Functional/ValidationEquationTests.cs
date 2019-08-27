using System;
using System.Collections.Generic;
using System.Text;
using Calculator.Functional;
using Calculator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests.Functional
{
    [TestClass]
    public class ValidationEquationTests
    {
        [TestMethod]
        public void PreparationEquationPutSpaces()
        {
            // arrange
            //string equation = "42+18";
            //string exected = "42 + 18";

            string equation = "42+18/(6+12/4)";
            string exected = "42 + 18 / ( 6 + 12 / 4 )";

            //string equation = "18/( 6 )";
            //string exected = "18 / ( 6 )";

            // act
            string actualElements = ValidationEquation.PreparationEquationPutSpaces(equation);

            // assert
            Assert.AreEqual(exected, actualElements);
        }

        [TestMethod]
        public void IsValidate()
        {
            // arrange
            //string equation = "42+18";
            //string exected = "42 + 18";

            string equation = "(42+18)/(6+12/4)";
            //string equation = "( 42 + 18 ) / ( 6 + 12 / 4 )";
            bool exected = true;

            //string equation = "18/( 6 )";
            //string exected = "18 / ( 6 )";

            // act
            bool actual = ValidationEquation.IsValidate(equation);

            // assert
            Assert.AreEqual(exected, actual);
        }
    }
}
