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

namespace WpfApp6_lab_5th
{
    public partial class MainWindow : Window
    {
        private int[,] matrix;
        private int rows = 0;
        private int cols = 0;
        private Random rnd = new Random();

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

        private void RandomBtn_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                StackPanel rowPanel = MatrixPanel.Children[i] as StackPanel;
                for (int j = 0; j < cols; j++)
                {
                    int value = rnd.Next(-20, 21);
                    matrix[i, j] = value;

                    TextBox box = rowPanel.Children[j] as TextBox;
                    box.Text = value.ToString();
                }
            }
        }

        private void CreateMatrix()
        {
            matrix = new int[rows, cols];
            MatrixPanel.Children.Clear();
            for (int i = 0; i < rows; i++)
            {
                StackPanel rowPanel = new StackPanel { Orientation = Orientation.Horizontal };
                for (int j = 0; j < cols; j++)
                {
                    var box = new TextBox
                    {
                        Width = 50,
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

            ResultPanel.Children.Clear();
        }

        private void Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = sender as TextBox;
            int[] coords = box.Tag as int[];

            if (int.TryParse(box.Text, out int value))
            {
                matrix[coords[0], coords[1]] = value;
            }
        }

        private void RotateBtn_Click(object sender, RoutedEventArgs e)
        {
            int newRows = cols;
            int newCols = rows;
            int[,] rotated = new int[newRows, newCols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    rotated[j, rows - 1 - i] = matrix[i, j];
                }
            }
            ResultPanel.Children.Clear();
            for (int i = 0; i < newRows; i++)
            {
                StackPanel rowPanel = new StackPanel { Orientation = Orientation.Horizontal };
                for (int j = 0; j < newCols; j++)
                {
                    var box = new TextBox
                    {
                        Width = 50,
                        Height = 30,
                        Margin = new Thickness(2),
                        Text = rotated[i, j].ToString(),
                        IsReadOnly = true,
                        Background = System.Windows.Media.Brushes.LightYellow
                    };
                    rowPanel.Children.Add(box);
                }
                ResultPanel.Children.Add(rowPanel);
            }
        }
    }
}
