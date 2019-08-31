using Calculator.Controller;
using Calculator.DI;
using Calculator.Functional;
using Calculator.Functional.Arithmetic;
using Calculator.Repositories;
using Calculator.Tests.Controller.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Calculator.Tests.Controller
{
    [TestClass]
    public class CalculatorControllerTests
    {
        private ICalculator FactoryMethod(IInputRepository inputRepositoryObjectStub, IPrintRepository printRepositoryObjectStub)
        {
            ISeparationEquation separationEquation = new ArithmeticSeparationEquation();
            ICalculationEquation calculationEquation = new ArithmeticCalculationEquation();

            ICalculatorRepository calculatorRepository = new CalculatorRepository(separationEquation, calculationEquation);

            CalculatorController calculator = new CalculatorController(inputRepositoryObjectStub, printRepositoryObjectStub, calculatorRepository);

            return calculator;
        }

        [TestMethod]
        public void SolveEquation()
        {
            // arrange
            Mock<IInputRepository> mockInputRepository = new Mock<IInputRepository>();
            Mock<IPrintRepository> mockPrintRepository = new Mock<IPrintRepository>();
            Mock<ICalculatorRepository> mockCalculatorRepository = new Mock<ICalculatorRepository>();

            mockInputRepository
                .Setup(repo => repo.GetEquation())
                .Returns(It.IsAny<string>());
            mockPrintRepository
                .Setup(repo => repo.Print(It.IsAny<double>()));
            mockCalculatorRepository
                .Setup(repo => repo.SolveEquation(It.IsAny<string>()))
                .Returns(It.IsAny<double>());

            CalculatorController controller = new CalculatorController(mockInputRepository.Object, mockPrintRepository.Object, mockCalculatorRepository.Object);

            // act
            controller.SolveEquation();

            // assert
            mockInputRepository.VerifyAll();
            mockPrintRepository.VerifyAll();
            mockCalculatorRepository.VerifyAll();
        }

        [TestMethod]
        public void SolveEquation_StabObject()
        {
            // arrange
            Queue<string> equations = new Queue<string>();
            equations.Enqueue("10 + -9");
            equations.Enqueue("( 100/5 +62*2 +(44-22  / 10)) +(84* 56/(12/6)+90 -  (5* 5 -   1))");
            equations.Enqueue("-10 * -9 + 100");
            equations.Enqueue("10+(0-6)");
            equations.Enqueue("( -10 * 2)/(12 + -2)");
            equations.Enqueue("17 + 9 / ( 4 - 1 ) * 65");
            equations.Enqueue("( 4 - 1 ) * 2");
            equations.Enqueue("55,6 * 5 / 1,1 + 900 - 98 * ( 458 / 2 + 90 ) - 100");
            equations.Enqueue("( -900 * 2 ) - 55 * ( 458 / 2 + 90 )");
            equations.Enqueue("(-45 / 8 / 2 - 10) - -55 + 87 * ( (45 + -48) / 2 * 5 + 90 / 5 )");
            equations.Enqueue("(5,2 + -98,8 / (5,6 - -1,4) * 4,1 * (50,5 / -5,5)) + -98,45 - -9,45 + 44,168");

            double[] answer = { 1, 2603.8, 190, 4, -2, 212, 6, -30209.272727272728, -3036, 955, 687, 491, 7067013, 491.70670129870132 };

            InputRepositoryStub inputRepositoryStub = new InputRepositoryStub(equations);
            PrintRepositoryStub printRepositoryStub = new PrintRepositoryStub();
            ICalculator controller = FactoryMethod(inputRepositoryStub, printRepositoryStub);

            for (int i = 0; i < equations.Count; i++)
            {
                // act
                controller.SolveEquation();

                // assert
                Assert.AreEqual(answer[i], printRepositoryStub.Result);
            }
        }

    }
}
