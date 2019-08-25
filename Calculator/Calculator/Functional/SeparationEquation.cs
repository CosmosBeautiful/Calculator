using Calculator.Models;
using System;
using System.Collections.Generic;

namespace Calculator.Functional
{
    public static class SeparationEquation
    {
        private static int GetNextElementAfterNestedEquation(string[] arrayElements, int item)
        {
            int skipCloseBraket = 0;

            for (int i = item + 1; i < arrayElements.Length; i++)
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

        private static string GetNestedEquation(string[] arrayElements, int startItem, int endItem)
        {
            string nestedEquation = "";

            for (int i = startItem; i <= endItem; i++)
            {
                nestedEquation += arrayElements[i] + ' ';
            }

            nestedEquation = nestedEquation.Remove(nestedEquation.Length - 1);
            return nestedEquation;
        }

        public static List<ElementEquation> GetElementsEquation(string equation)
        {
            List<ElementEquation> elements = new List<ElementEquation>();

            string[] arrayElements = equation.Split(' ');

            double number = 0;
            for (int i = 0; i < arrayElements.Length; i++)
            {
  
                switch (arrayElements[i])
                {
                    case "(":
                        int nextItem = GetNextElementAfterNestedEquation(arrayElements, i);
                        string nestedEquation = GetNestedEquation(arrayElements, i, nextItem);
                        elements.Add(new ElementEquation(OperatorType.Brackets, nestedEquation));

                        i = nextItem;
                        break;
                    case "*":
                        elements.Add(new ElementEquation(number, OperatorType.Mul));
                        break;
                    case "/":
                        elements.Add(new ElementEquation(number, OperatorType.Del));
                        break;
                    case "+":
                        elements.Add(new ElementEquation(number, OperatorType.Sum));
                        break;
                    case "-":
                        elements.Add(new ElementEquation(number, OperatorType.Sub));
                        break;
                }

                Double.TryParse(arrayElements[i], out number);
            }

            return elements;
        }
    }
}
