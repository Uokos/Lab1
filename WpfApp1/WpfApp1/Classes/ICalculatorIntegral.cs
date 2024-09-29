using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Classes
{
    public interface ICalculatorIntegral
    {
        double Calculate(double upperLimit, double lowerLimit, int amount, Func<double, double> func);
    }
}