using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6_lab_6th
{
    public class Power
    {
        private double first;
        private double second;

        public Power(double first, double second)
        {
            this.first = first;
            this.second = second;
        }

        public double power()
        {
            return Math.Pow(first, second);
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstBox.Text, out double first) &&
                double.TryParse(SecondBox.Text, out double second))
            {
                Power np = new Power(first, second);
                double result = np.power();

                ResultText.Text = $"Результат: {first}^{second} = {result}";
            }
            else
            {
                MessageBox.Show("Введите корректные числа");
            }
        }
    }
}