using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Calculator.Functional
{
    public static class ValidationEquation
    {
        private static bool IsOperation(char elem)
        {
            return (elem == '(' || elem == ')' || elem == '+' || elem == '-' || elem == '*' || elem == '/');
        }

        public static string PreparationEquationPutSpaces(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                if (IsOperation(equation[i]))
                {
                    if ( ((i + 1) < equation.Length) && (equation[i + 1] != ' ') )
                    {
                        equation = equation.Insert(i + 1, " ");
                    }

                    if ( ((i - 1) >= 0) && (equation[i - 1] != ' ') )
                    {
                        equation = equation.Insert(i, " ");
                        i++;
                    }
                }
            }

            return equation;
        }

        public static bool IsValidate(string equation)
        {
            //^(\d+([*+-]|/(?!0)))+\d+$
            Regex rgx = new Regex(@"^([( ]*\d+([ )]*[*+-]|[ )]*/(?!0))[( ]*)+\d+[ )]*[ )]*$");
            bool isRgxValid = rgx.IsMatch(equation);

            int countBrackets = 0;
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '(')
                {
                    countBrackets++;
                }

                if (equation[i] == ')')
                {
                    countBrackets--;
                }
            }

            return ( isRgxValid && (countBrackets == 0) ); 
        }
    }
}
