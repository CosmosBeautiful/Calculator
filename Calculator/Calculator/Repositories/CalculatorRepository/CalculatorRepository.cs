using Calculator.Functional;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {

        #region NestedEquation
       
        #endregion

        public double SolveEquation(string equation)
        {
            double result = 0;
            List<ElementEquation> elements = SeparationEquation.GetElementsEquation(equation);

            return result;
        }
    }
}
