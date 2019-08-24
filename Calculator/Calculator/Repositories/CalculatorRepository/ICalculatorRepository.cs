using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Repositories
{
    public interface ICalculatorRepository
    {
        double SolveEquation(string equation);
    }
}