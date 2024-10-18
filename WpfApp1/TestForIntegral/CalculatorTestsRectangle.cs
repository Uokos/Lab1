using WPFIntegral.Classes;

namespace TestForIntegral
{
    public class CalculatorTestsRectangle
    {
        private Func<double, double> func = x => 11 * x - Math.Log(11 * x) - 2;
        ICalculatorIntegral calculator = new RectangleIntegral();
        [Test]
        public void Calculator_RectangleCalculator_ReturnsCorrectResult()
        {
            int lowerLimit = 1;
            int upperLimit = 100_000;
            int amount = 100_000_000;
            double actual = calculator.Calculate(upperLimit, lowerLimit, amount, func);
            Assert.That(actual, Is.EqualTo(5.499850891582412 * 1e10).Within(1e2));
        }

        [Test]
        public void WhenDownIsGreaterThanUpperLimit_ThrowsException()
        {
            int lowerLimit = 100;
            int upperLimit = 1;
            int amount = 100_000_000;
            Assert.Throws<ArgumentException>(() => calculator.Calculate(upperLimit, lowerLimit, amount, func));
        }

        [Test]
        public void WhenCountOfSplitsIsNegative_ThrowsException()
        {
            int lowerLimit = 1;
            int upperLimit = 100;
            int amount = -1;
            Assert.Throws<ArgumentOutOfRangeException>(() => calculator.Calculate(upperLimit, lowerLimit, amount, func));
        }
    }
}