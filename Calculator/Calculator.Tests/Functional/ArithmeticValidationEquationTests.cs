using Calculator.Functional.Arithmetic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Calculator.Tests.Functional
{
    [TestClass]
    public class ArithmeticValidationEquationTests
    {
        private ArithmeticValidationEquation arithmeticValidation;

        [TestInitialize]
        public void ClassInitialize()
        {
            arithmeticValidation = new ArithmeticValidationEquation();
        }

        [TestMethod]
        public void PreparationEquationPutSpaces()
        {
            // arrange
            Dictionary<string, string> equations = new Dictionary<string, string>
            {
                { "42+18/( 6+12 /4 )", "42 + 18 / ( 6 + 12 / 4 )"},
                { "42+18/(6+12/4)", "42 + 18 / ( 6 + 12 / 4 )"},
                { "18/( 6 )", "18 / ( 6 )"},
                { "( 4 -1) *2", "( 4 - 1 ) * 2"}
            };

            foreach (var equation in equations)
            {
                // act
                string actualEquation = arithmeticValidation.PreparationEquationPutSpaces(equation.Key);

                // assert
                Assert.AreEqual(equation.Value, actualEquation, $"{equation.Value} != {actualEquation}");
            }
        }

        [TestMethod]
        public void IsValidate()
        {
            // arrange
            Dictionary<string, bool> equations = new Dictionary<string, bool>
            {
                { "42 + 18 / ( 6 + 12 / 4 )", true},
                { "12/6+10-( 5*(6+ 2))+ 27", true},
                { "( 1*2 )/( 12/6 )", true},
                { "(100 /5 +6 * 2+ (44- 22/ 10))+ (84* 56/(12/ 6 )+90-(5*5-1) )", true},
                { "5 * 4) *65", false},
                { "( 4 - 1 ) * 2x", false}
            };

            foreach (var equation in equations)
            {
                // act
                bool actualValid = arithmeticValidation.IsValidate(equation.Key);

                // assert
                Assert.AreEqual(equation.Value, actualValid, $"{equation.Value} != {actualValid}");
            }
        }
    }
}
