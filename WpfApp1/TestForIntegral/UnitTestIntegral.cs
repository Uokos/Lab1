using System;
using NUnit.Framework;
using WPFIntegral.Classes;

namespace TestForIntegral
{
    public class CalculatorTests
    {
        private Func<double, double> func = x => 11 * x - Math.Log(11 * x) - 2;

        [Test]
        public void Calculator_RectangleCalculator_ReturnsCorrectResult()
        {
            int lowerLimit = 1;
            int upperLimit = 1_000;
            int amount = 100_000_000;
            ICalculatorIntegral calculator = new RectangleIntegral();
            double actual = calculator.Calculate(upperLimit, lowerLimit, amount, func);
            Assert.That(actual, Is.EqualTo(5.489692247343492 * 1e6).Within(1e-1));
        }

        [Test]
        public void Calculator_TrapezoidCalculator_ReturnsCorrectResult()
        {
            int lowerLimit = 1;
            int upperLimit = 1_000;
            int amount = 100_000_000;
            ICalculatorIntegral calculator = new TrapezoidIntegral();
            double actual = calculator.Calculate(upperLimit, lowerLimit, amount, func);
            Assert.That(actual, Is.EqualTo(5.489692247343492 * 1e6).Within(2e-1));
        }

        [Test]
        public void WhenDownIsGreaterThanUpperLimit_ThrowsException()
        {
            int lowerLimit = 100;
            int upperLimit = 1;
            int amount = 100_000_000;
            ICalculatorIntegral calculator = new RectangleIntegral();
            Assert.Throws<ArgumentException>(() => calculator.Calculate(upperLimit, lowerLimit, amount, func));
        }

        [Test]
        public void WhenCountOfSplitsIsNegative_ThrowsException()
        {
            int lowerLimit = 1;
            int upperLimit = 100;
            int amount = -1;
            ICalculatorIntegral calculator = new RectangleIntegral();
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate(upperLimit, lowerLimit, amount, func));
        }

        [Test]
        public void IntegralIsPossitive()
        {
            int lowerLimit = 1;
            int upperLimit = 100;
            int countOfSplits = 1_000_000;
            ICalculatorIntegral calculator = new TrapezoidIntegral();
            double actual = calculator.Calculate(upperLimit, lowerLimit, countOfSplits, func);
            Assert.That(actual, Is.GreaterThanOrEqualTo(0));
        }
    }
}