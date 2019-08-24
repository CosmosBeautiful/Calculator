using System;

namespace Calculator.Repositories
{
    public class InputRepository : IInputRepository
    {
        public string GetEquation()
        {
            string equation;
#if !DEBUG
            Console.WriteLine("Введите выражение:");
            equation = Console.ReadLine();
#else
            equation = "42 + 18 / ( 6 + 12 / 4 )";
#endif

            //ToDo: Validation equation
            return equation;
        }
    }
}
