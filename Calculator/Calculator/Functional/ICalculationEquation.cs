using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Functional
{
    public interface ICalculationEquation
    {
        LevelType GetMaxLevelOperation(List<ElementEquation> elements);
        double MakeOperation(ElementEquation x, OperatorType operatorType, ElementEquation y);
    }
}
