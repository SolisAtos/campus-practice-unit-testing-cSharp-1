using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Tests
{
    public class SeriesShould
    {
        [Fact]
        public void VerifyFibonacci()
        {
            // Arrange
            Mock<ICalculator> calculatorMock = new Mock<ICalculator>();
            calculatorMock.Setup(a => a.Add(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int first, int second) => first + second);
            Series series = new Series(calculatorMock.Object);

            int testNumber = 6;
            int expected = 8;
            int actual;

            // Act
            actual = series.Fibonacci(testNumber);

            // Assert
            Assert.Equal(expected, actual);
            calculatorMock.Verify(a => a.Add(It.IsAny<int>(), It.IsAny<int>()));
        }

        [Fact]
        public void VerifyFactorial()
        {
            // Arrange
            Mock<ICalculator> calculatorMock = new Mock<ICalculator>();
            calculatorMock.Setup(a => a.Mul(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int first, int second) => first * second);
            Series series = new Series(calculatorMock.Object);

            int testNumber = 9;
            int expected = 362880;
            int actual;

            // Act
            actual = series.Factorial(testNumber);

            // Assert
            Assert.Equal(expected, actual);
            calculatorMock.Verify(a => a.Mul(It.IsAny<int>(), It.IsAny<int>()));
        }
    }
}
