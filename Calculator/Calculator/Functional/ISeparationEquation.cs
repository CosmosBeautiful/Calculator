using Calculator.Models;
using System.Collections.Generic;

namespace Calculator.Functional
{
    public interface ISeparationEquation
    {
        List<ElementEquation> GetElementsEquation(string equation);
    }
}
