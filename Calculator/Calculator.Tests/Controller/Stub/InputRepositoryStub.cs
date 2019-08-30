using Calculator.Functional;
using Calculator.Functional.Arithmetic;
using Calculator.Repositories;
using System.Collections.Generic;

namespace Calculator.Tests.Controller.Stub
{
    public class InputRepositoryStub : IInputRepository
    {
        public Queue<string> equations;
        public bool isValid;

        private IValidationEquation validationEquation;

        public InputRepositoryStub(Queue<string> equations)
        {
            this.equations = equations;
            this.validationEquation = new ArithmeticValidationEquation();
        }

        public string GetEquation()
        {
            string equation = equations.Dequeue();

            isValid = validationEquation.IsValidate(equation);
            if (isValid == true)
            {
                equation = validationEquation.PreparationEquationPutSpaces(equation);
            }

            return equation;
        }
    }
}
