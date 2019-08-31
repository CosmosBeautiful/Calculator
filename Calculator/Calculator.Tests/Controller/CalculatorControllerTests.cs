using Calculator.Controller;
using Calculator.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Calculator.Tests.Controller
{
    [TestClass]
    public class CalculatorControllerTests
    {
        [TestMethod]
        public void SolveEquation_DependencyInjection_VerifyAll()
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
    }
}
