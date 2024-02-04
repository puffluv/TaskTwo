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

namespace TaskTwo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnAddButtonClick(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplayResult((a, b) => a + b);
        }

        private void OnSubtractButtonClick(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplayResult((a, b) => a - b);
        }

        private void OnMultiplyButtonClick(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplayResult((a, b) => a * b);
        }

        private void OnDivideButtonClick(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplayResult((a, b) =>
            {
                if (b != 0 )
                    return a / b;
                else
                    return double.NaN; // Handle division by zero
            });
        }

        private void CalculateAndDisplayResult(Func<double, double, double> operation)
        {
            try
            {
                double numberA = Convert.ToDouble(TextBoxA.Text);
                double numberB = Convert.ToDouble(TextBoxB.Text);
                double result = operation(numberA, numberB);
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
