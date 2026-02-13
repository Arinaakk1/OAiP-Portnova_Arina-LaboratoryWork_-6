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

namespace WpfApp6_lab_4th
{
    public partial class MainWindow : Window
    {
        private double[,] matrix;
        private int rows = 0;
        private int cols = 0;

        public MainWindow()
        {
            InitializeComponent();
            CreateMatrix();
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RowsBox.Text, out int newRows) && newRows > 0 &&
                int.TryParse(ColsBox.Text, out int newCols) && newCols > 0)
            {
                rows = newRows;
                cols = newCols;
                CreateMatrix();
            }
            else
            {
                MessageBox.Show("Введите корректные размеры матрицы");
            }
        }

        private void CreateMatrix()
        {
            matrix = new double[rows, cols];
            MatrixPanel.Children.Clear();
            for (int i = 0; i < rows; i++)
            {
                StackPanel rowPanel = new StackPanel { Orientation = Orientation.Horizontal };
                for (int j = 0; j < cols; j++)
                {
                    var box = new TextBox
                    {
                        Width = 60,
                        Height = 30,
                        Margin = new Thickness(2),
                        Text = "0",
                        Tag = new int[] { i, j }
                    };
                    box.TextChanged += Box_TextChanged;
                    rowPanel.Children.Add(box);
                }

                MatrixPanel.Children.Add(rowPanel);
            }
        }

        private void Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            int[] coords = box.Tag as int[];
            if (double.TryParse(box.Text, out double value))
            {
                matrix[coords[0], coords[1]] = value;
            }
        }

        private void SwapBtn_Click(object sender, RoutedEventArgs e)
        {
            if (rows == 0 || cols == 0) return;
            int maxRow = 0;
            int minRow = 0;
            double maxVal = matrix[0, 0];
            double minVal = matrix[0, 0];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] > maxVal)
                    {
                        maxVal = matrix[i, j];
                        maxRow = i;
                    }
                    if (matrix[i, j] < minVal)
                    {
                        minVal = matrix[i, j];
                        minRow = i;
                    }
                }
            }
            if (maxRow == minRow)
            {
                ResultText.Text = $"Макс и мин элементы в одной строке. Менять нечего.";
                return;
            }
            for (int j = 0; j < cols; j++)
            {
                double temp = matrix[maxRow, j];
                matrix[maxRow, j] = matrix[minRow, j];
                matrix[minRow, j] = temp;
            }
            UpdateMatrixDisplay();
            ResultText.Text = $"Строка {maxRow + 1} (с макс={maxVal}) и строка {minRow + 1} (с мин={minVal}) поменялись местами";
        }

        private void UpdateMatrixDisplay()
        {
            for (int i = 0; i < rows; i++)
            {
                StackPanel rowPanel = MatrixPanel.Children[i] as StackPanel;
                for (int j = 0; j < cols; j++)
                {
                    TextBox box = rowPanel.Children[j] as TextBox;
                    box.Text = matrix[i, j].ToString();
                }
            }
        }
    }
}