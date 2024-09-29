using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateIntegral();
        }

        public void CalculateIntegral()
        {
            double upperLimit = Convert.ToDouble(tbUpperLimit.Text);
            double lowerLimit = Convert.ToDouble(tbLowerLimit.Text);
            int amount = Convert.ToInt32(tbAmount.Text);

            ICalculatorIntegral calculatorIntegral = GetCalculator();
            double answer = calculatorIntegral.Calculate(upperLimit, lowerLimit, amount, x=> 11 * x - Math.Log( 11 * x ) - 2);
            tbAnswer.Text = answer.ToString();
        }

        private ICalculatorIntegral GetCalculator()
        {
            return (global::System.Object)cmbIntegralType.SelectedIndex switch
            {
                0 => new RectangleIntegral(),
                1 => new TrapezoidIntegral(),
                _ => new RectangleIntegral(),
            };
        }
    }
}