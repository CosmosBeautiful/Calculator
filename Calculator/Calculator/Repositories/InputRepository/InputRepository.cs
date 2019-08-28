using Calculator.Functional;
using System;

namespace Calculator.Repositories
{
    public class InputRepository : IInputRepository
    {
        private IValidationEquation validationEquation;

        public InputRepository(IValidationEquation validationEquation)
        {
            this.validationEquation = validationEquation;
        }

        public string GetEquation()
        {
            string equation;

            while (true)
            {
                Console.WriteLine("Введите выражение:");
                Console.WriteLine("Подсказка: 42 + 18 / ( 6 + 12 / 4 )\n");
                equation = Console.ReadLine();

                bool isValid = validationEquation.IsValidate(equation);
                if (isValid == true)
                {
                    equation = validationEquation.PreparationEquationPutSpaces(equation);
                    return equation;
                }
                Console.WriteLine("Невалидное выражение, попробуйте снова.");
            }
        }
    }
}
