using Calculator.Repositories;

namespace Calculator.Tests.Controller.Stub
{
    public class PrintRepositoryStub : IPrintRepository
    {
        public double Result;
        public void Print(double result)
        {
            Result = result;
        }
    }
}
