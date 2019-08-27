using System;

namespace Calculator.Repositories
{
    public class PrintRepository : IPrintRepository
    {
        public void Print(double result)
        {
            Console.WriteLine($"Ответ: {result}");
        }
    }
}
