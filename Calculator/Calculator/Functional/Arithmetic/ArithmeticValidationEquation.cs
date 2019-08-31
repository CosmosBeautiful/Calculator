using System.Text.RegularExpressions;

namespace Calculator.Functional.Arithmetic
{
    public class ArithmeticValidationEquation : IValidationEquation
    {
        private bool IsOperation(char elem)
        {
            return (elem == '(' || elem == ')' || elem == '+' || elem == '-' || elem == '*' || elem == '/');
        }

        private string AddWrapperNegativeNumber(string equation, int itemNegativeOperator, int countNumber)
        {
            string wrapperBegin = "( 0 ";
            string wrapperEnd = " )";
            int countWrapper = wrapperBegin.Length;
            int itemEndNegativeNumber = (itemNegativeOperator + countWrapper + countNumber);

            equation = equation.Insert(itemNegativeOperator, wrapperBegin);
            equation = equation.Insert(itemEndNegativeNumber, wrapperEnd);

            return equation;
        }

        private string PreparationNegativeNumber(string equation, int item)
        {
            if ( (equation[item]== '(') || (equation[item] == ')') )
            {
                return equation;
            }

            bool isNegativeOperator = false;
            int itemNegativeOperator = 0;

            int countNegativeNumber = 0;

            for (int i = ++item; i < equation.Length; i++)
            {
                if (isNegativeOperator == true)
                {
                    countNegativeNumber++;

                    int number;
                    bool isNumber = int.TryParse(equation[i].ToString(), out number);
             
                    if ( (isNumber == false) && (equation[i] != ',')  && (equation[i] != ' ') )
                    {
                        equation = AddWrapperNegativeNumber(equation, itemNegativeOperator, countNegativeNumber);
                        break;
                    }

                    if ( i == (equation.Length - 1) )
                    {
                        equation = AddWrapperNegativeNumber(equation, itemNegativeOperator, countNegativeNumber + 1);
                        break;
                    }
                }
                else
                {
                    if (equation[i] == '-')
                    {
                        isNegativeOperator = true;
                        itemNegativeOperator = i;
                    }
                    else if (equation[i] != ' ')
                    {
                        break;
                    }
                }
            }

            return equation;
        }

        private string RemoveDoubleSpace(string equation)
        {
            Regex rgxDoubleSpace = new Regex(@"\s\s+");
            equation = rgxDoubleSpace.Replace(equation, " ");

            return equation;
        }

        public string PreparationEquationPutSpaces(string equation)
        {
            for (int i = 0; i < equation.Length; i++)
            {
                if (IsOperation(equation[i]))
                {
                    equation = PreparationNegativeNumber(equation, i);

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

            equation = RemoveDoubleSpace(equation);

            return equation;
        }

        public bool IsValidate(string equation)
        {
            string beginBrackets = "[( -]*";
            string endBrackets = "[ )]*";

            string number = "\\d+,?\\d*";
            string operand = "([*+-]|[ )]*/(?!0))";

            string pattern = $"({beginBrackets}{number}{endBrackets}{operand}{beginBrackets})+{number}{endBrackets}";
            Regex rgx = new Regex(@"^"+ pattern + "$");
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
