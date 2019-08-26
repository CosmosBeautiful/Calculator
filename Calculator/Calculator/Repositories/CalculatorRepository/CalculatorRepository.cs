using Calculator.Functional;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        public double SolveEquation(string equation)
        {
            List<ElementEquation> elements = SeparationEquation.GetElementsEquation(equation);

            while (elements.Count > 1)
            {
                LevelType maxLevel = CalculationEquation.GetMaxLevelOperation(elements);

                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Operation.Level == maxLevel)
                    {
                        if (elements[i].Operation.Operator == OperatorType.Brackets)
                        {
                            double resultNested = SolveEquation(elements[i].NestedEquation);
                            elements[i] = new ElementEquation(resultNested);
                            if ( elements.Count > (i + 1) )
                            {
                                elements[i].Operation = elements[i + 1].Operation;
                                elements.RemoveAt(i + 1);
                                i--;
                            }
                        }
                        else
                        {
                            if (elements.Count >= 2)
                            {
                                elements[i + 1].Number = CalculationEquation.CalculationElements(elements[i], elements[i].Operation.Operator, elements[i + 1]);
                                elements.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }
            return elements[0].Number;
        }
    }
}
