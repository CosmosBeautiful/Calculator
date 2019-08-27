using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Functional
{
    public static class CalculationEquation
    {
        public static LevelType GetMaxLevelOperation(List<ElementEquation> elements)
        {
            LevelType max = LevelType.Low;

            foreach (ElementEquation element in elements)
            {
                if (element.Operation.Level > max)
                {
                    max = element.Operation.Level;
                }
            }

            return max;
        }

        public static double MakeOperation(ElementEquation x, OperatorType operatorType, ElementEquation y)
        {
            double result = 0;
            switch (operatorType)
            {
                case OperatorType.Mul:
                    result = x.Number * y.Number;
                    break;
                case OperatorType.Del:
                    result = x.Number / y.Number;
                    break;
                case OperatorType.Sum:
                    result = x.Number + y.Number;
                    break;
                case OperatorType.Sub:
                    result = x.Number - y.Number;
                    break;
            }
            return result;
        }
    }
}
