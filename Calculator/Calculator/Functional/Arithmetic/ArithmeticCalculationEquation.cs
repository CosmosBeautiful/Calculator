using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Functional.Arithmetic
{
    public class ArithmeticCalculationEquation : ICalculationEquation
    {
        public LevelType GetMaxLevelOperation(List<ElementEquation> elements)
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

        public double MakeOperation(ElementEquation x, OperatorType operatorType, ElementEquation y)
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
