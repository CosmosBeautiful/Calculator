using Calculator.Controller;
using Calculator.Repositories;
using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            //Poor Man's DI
            IInputRepository inputRepository = new InputRepository();
            IPrintRepository printRepository = new PrintRepository();
            ICalculatorRepository calculatorRepository = new CalculatorRepository();
            CalculatorController calculator = new CalculatorController(inputRepository, printRepository, calculatorRepository);

            calculator.SolveEquation();

            //Выполнение ->
            //(
            //Ввод данных

            //Вызов обработчика

            //Вывод данных
            //)
        }
    }
}
