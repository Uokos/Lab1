using WPFIntegral.Classes;

namespace TestForIntegral
{
    public class CalculatorTestsTrapezoid
    {
        ICalculatorIntegral calculator = new TrapezoidIntegral();
        private Func<double, double> func = x => 11 * x - Math.Log(11 * x) - 2;
        [Test]
        public void Calculator_TrapezoidCalculator_ReturnsCorrectResult()
        {
            int lowerLimit = 1;
            int upperLimit = 1_000;
            int amount = 100_000_000;
            double actual = calculator.Calculate(upperLimit, lowerLimit, amount, func);
            Assert.That(actual, Is.EqualTo(5.489692247343492 * 1e6).Within(2e-1));
        }

        [Test]
        public void IntegralIsPossitive()
        {
            int lowerLimit = 1;
            int upperLimit = 100;
            int countOfSplits = 1_000_000;
            double actual = calculator.Calculate(upperLimit, lowerLimit, countOfSplits, func);
            Assert.That(actual, Is.GreaterThanOrEqualTo(0));
        }
    }
}