using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculators.Tests
{
    public class CalculatorShould
    {
        [Fact]
        public void ValidateAdd()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float firstNumber = 3;
            float secondNumber = 17;
            float expected = 20;
            float actual;

            // Act
            actual = calculator.Add(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValidateSub()
        {
            // Arrange
            Calculator calculator = new Calculator();
            float firstNumber = 5;
            float secondNumber = 10;
            float expected = -5;
            float actual;

            // Act
            actual = calculator.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5, 10, 50)]
        [InlineData(-6, -1, 6)]
        [InlineData(8, -9, -72)]
        [InlineData(92, 19, 1748)]
        [InlineData(76.68, 11.47, 879.51965)]
        public void ValidateMul(float firstNumber, float SecondNumber, float expected)
        {
            // Arrange
            Calculator calculator = new Calculator();
            float actual;

            // Act
            actual = calculator.Mul(firstNumber, SecondNumber);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(50, 5, 10)]
        [InlineData(-52, -4, 13)]
        [InlineData(44, -72, -0.61111)]
        [InlineData(56, 61, 0.91803)]
        [InlineData(54.63, 4.28, 12.76402)]
        public void ValidateDiv(float firstNumber, float SecondNumber, float expected)
        {
            // Arrange
            Calculator calculator = new Calculator();
            float actual;

            // Act
            actual = calculator.Div(firstNumber, SecondNumber);

            // Assert
            Assert.Equal(expected, actual, 5);
        }

        [Fact]
        public void RaiseErrorWhenDividingByZero()
        {
            // Arrange
            Calculator calculator = new Calculator();

            // Act
            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Div(1, 0));
        }
    }
}
