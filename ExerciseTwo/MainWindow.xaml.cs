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

namespace ExerciseTwo
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
            string newItem = InputTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(newItem) && IsString(newItem))
            {
                ItemList.Items.Add(newItem);
                InputTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Введите корректное значение (непустую строку).", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsString(string value)
        {
            return !value.Any(char.IsDigit); // проверка, что строка не содержит цифр
        }
    }
}
