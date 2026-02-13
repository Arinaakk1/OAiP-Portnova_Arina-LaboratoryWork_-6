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

namespace WpfApp6_lab_3d
{
    public partial class MainWindow : Window
    {
        private int[] array;
        private int size = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreateArray();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(SizeBox.Text, out int newSize) && newSize > 0 && newSize <= 20)
            {
                size = newSize;
                CreateArray();
            }
            else
            {
                MessageBox.Show("Введите размер массива от 1 до 20");
            }
        }

        private void CreateArray()
        {
            array = new int[size];
            ArrayPanel.Children.Clear();

            for (int i = 0; i < size; i++)
            {
                var box = new TextBox
                {
                    Width = 50,
                    Height = 30,
                    Margin = new Thickness(2),
                    Text = "0",
                    Tag = i
                };
                box.TextChanged += Box_TextChanged;
                ArrayPanel.Children.Add(box);
            }
        }

        private void Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            int index = (int)box.Tag;
            if (int.TryParse(box.Text, out int value))
            {
                array[index] = value;
            }
        }

        private void ReplaceBtn_Click(object sender, RoutedEventArgs e)
        {
            string result = "Результат: ";
            for (int i = 0; i < size; i++)
            {
                int num = array[i];
                if (num % 3 == 0 && num % 5 == 0)
                {
                    array[i] = -3;
                }
                else if (num % 3 == 0)
                {
                    array[i] = -1;
                }
                else if (num % 5 == 0)
                {
                    array[i] = -2;
                }
                result += array[i] + " ";
            }
            ResultText.Text = result;
        }
    }
}