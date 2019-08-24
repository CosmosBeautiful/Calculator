using Calculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {

        #region NestedEquation
        private int GetNextElementAfterNestedEquation(string[] arrayElements, int item)
        {
            int skipCloseBraket = 0;

            for (int i = item; i < arrayElements.Length; i++)
            {
                if (arrayElements[i] == "(")
                {
                    skipCloseBraket++;
                    continue;
                }

                if (arrayElements[i] == ")")
                {
                    if (skipCloseBraket > 0)
                    {
                        skipCloseBraket--;
                        continue;
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            throw new ArgumentOutOfRangeException();
        }

        private string GetNestedEquation(string[] arrayElements, int startItem, int endItem)
        {
            string nestedEquation = "";

            for (int i = startItem; i <= endItem; i++)
            {
                nestedEquation += arrayElements[i] + ' ';
            }

            return nestedEquation;
        }
        #endregion

        private List<ElementEquation> SeparationElementsEquation(string equation)
        {
            List<ElementEquation> elements = new List<ElementEquation>();

            string[] arrayElements = equation.Split(' ');

            for (int i = 0; i < arrayElements.Length; i++ )
            {
                double number;

                switch (arrayElements[i])
                {
                    case "(":
                        int nextItem = GetNextElementAfterNestedEquation(arrayElements, i);
                        string nestedEquation = GetNestedEquation(arrayElements, i, nextItem);
                        elements.Add(new ElementEquation(OperatorType.Brackets, nestedEquation));

                        i = nextItem;
                        break;
                    case "*":
                        number = Double.Parse(arrayElements[i]);
                        elements.Add( new ElementEquation(number, OperatorType.Mul) );
                        break;
                    case "/":
                        number = Double.Parse(arrayElements[i]);
                        elements.Add(new ElementEquation(number, OperatorType.Del));
                        break;
                    case "+":
                        number = Double.Parse(arrayElements[i]);
                        elements.Add(new ElementEquation(number, OperatorType.Sum));
                        break;
                    case "-":
                        number = Double.Parse(arrayElements[i]);
                        elements.Add(new ElementEquation(number, OperatorType.Sub));
                        break;
                }
            }

            return elements;
        }

        public double SolveEquation(string equation)
        {
            double result = 0;
            List<ElementEquation> elements = SeparationElementsEquation(equation);

            return result;
        }
    }
}
