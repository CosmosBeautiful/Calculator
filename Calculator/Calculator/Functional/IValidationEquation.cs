namespace Calculator.Functional
{
    public interface IValidationEquation
    {
        string PreparationEquationPutSpaces(string equation);

        bool IsValidate(string equation);
    }
}
