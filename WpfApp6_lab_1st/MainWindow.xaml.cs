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

namespace WpfApp6_lab_1st
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double a = double.Parse(num1Box.Text);
                double b = double.Parse(num2Box.Text);
                double c = double.Parse(num3Box.Text);

                double r1 = a > 0 ? a * a : Math.Pow(a, 4);
                double r2 = b > 0 ? b * b : Math.Pow(b, 4);
                double r3 = c > 0 ? c * c : Math.Pow(c, 4);

                resultText.Text = $"Результаты:\n" +
                                  $"1: {r1}\n" +
                                  $"2: {r2}\n" +
                                  $"3: {r3}";
            }
            catch
            {
                MessageBox.Show("Вводи нормальные числа!");
            }
        }
    }
}