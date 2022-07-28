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
            int testNumber = 9;
            int expected = 362880;
            int actual;
            Mock<ICalculator> calculatorMock = new Mock<ICalculator>();
            calculatorMock.Setup(a => a.Mul(testNumber, 40320)).Returns(expected);
            calculatorMock.Setup(a => a.Mul(8, 5040)).Returns(40320);
            calculatorMock.Setup(a => a.Mul(7, 720)).Returns(5040);
            calculatorMock.Setup(a => a.Mul(6, 120)).Returns(720);
            calculatorMock.Setup(a => a.Mul(5, 24)).Returns(120);
            calculatorMock.Setup(a => a.Mul(4, 6)).Returns(24);
            calculatorMock.Setup(a => a.Mul(3, 2)).Returns(6);
            calculatorMock.Setup(a => a.Mul(2, 1)).Returns(2);
            Series series = new Series(calculatorMock.Object);

            // Act
            actual = series.Factorial(testNumber);

            // Assert
            Assert.Equal(expected, actual);
            calculatorMock.Verify(a => a.Mul(9, 40320));
            calculatorMock.Verify(a => a.Mul(8, 5040));
            calculatorMock.Verify(a => a.Mul(7, 720));
            calculatorMock.Verify(a => a.Mul(6, 120));
            calculatorMock.Verify(a => a.Mul(5, 24));
            calculatorMock.Verify(a => a.Mul(4, 6));
            calculatorMock.Verify(a => a.Mul(3, 2));
            calculatorMock.Verify(a => a.Mul(2, 1));

        }
    }
}
