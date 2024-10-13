using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral.Classes
{
    public class RectangleIntegral : ICalculatorIntegral
    {
        public double Calculate(double upper, double lower, int amount, Func<double,double> func) 
        {
            if (upper < lower)
                throw new ArgumentException("Нижний предел больше верхнего");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Некорректное число разбиений");
            double height = (upper - lower)/amount;
            double sum = 0;
            lower += 0.5 * height;
            for (int i = 0;i<amount; i++)
            {
                sum += func(lower+i*height);
            }
            return sum*height;
        }
    }
}
