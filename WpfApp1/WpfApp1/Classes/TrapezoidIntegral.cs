using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFIntegral.Classes
{
    public class TrapezoidIntegral : ICalculatorIntegral
    {
        public double Calculate(double upper, double lower,int amount, Func<double, double> func)
        {
            if (upper < lower)
                throw new ArgumentException("Нижний предел больше верхнего");

            if (amount <= 0)
                throw new ArgumentOutOfRangeException("Некорректное число разбиений");

            double height = (upper-lower)/amount;
            double answer = 0;
            double border = lower;
            for (int i = 0;i<amount;i++)
            {
                border += height;
                answer += func(border);
            }
            answer += (func(upper) - func(lower)) / 2;
            answer *= height;
            return answer;
        }
    }
}
