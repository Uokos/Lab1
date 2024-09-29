using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    class RectangleIntegral : ICalculatorIntegral
    {
        public double Calculate(double upper, double lower, int amount, Func<double,double> func) 
        {
            double height = (upper - lower)/amount;
            double sum = 0;
            for (int i = 0;i<amount; i++)
            {
                sum += func(lower+i*height);
            }
            return sum*height;
        }
    }
}
