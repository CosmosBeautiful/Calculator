using Calculator.Functional;
using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private void SolveNestedEquation(ref List<ElementEquation> elements, ref int i)
        {
            double resultNested = SolveEquation(elements[i].NestedEquation);
            elements[i] = new ElementEquation(resultNested);
            if (elements.Count > (i + 1))
            {
                elements[i].Operation = elements[i + 1].Operation;
                elements.RemoveAt(i + 1);
                i--;
            }
        }

        private void MakeOperation(ref List<ElementEquation> elements, ref int i)
        {
            if (elements.Count >= 2)
            {
                elements[i + 1].Number = CalculationEquation.MakeOperation(elements[i], elements[i].Operation.Operator, elements[i + 1]);
                elements.RemoveAt(i);
                i--;
            }
        }

        private double GetResultEquation(List<ElementEquation> elements)
        {
            if (elements.Count != 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return elements[0].Number;
        }

        public double SolveEquation(string equation)
        {
            List<ElementEquation> elements = SeparationEquation.GetElementsEquation(equation);

            while ( (elements.Count > 1) || (elements[0].Operation.Operator == OperatorType.Brackets) )
            {
                LevelType maxLevel = CalculationEquation.GetMaxLevelOperation(elements);

                for (int i = 0; i < elements.Count ; i++)
                {
                    if (elements[i].Operation.Level == maxLevel)
                    {
                        if (elements[i].Operation.Operator == OperatorType.Brackets)
                        {
                            SolveNestedEquation(ref elements, ref i);
                        }
                        else
                        {
                            MakeOperation(ref elements, ref i);
                        }
                    }
                }
            }

            double result = GetResultEquation(elements);
            return result;
        }
    }
}
