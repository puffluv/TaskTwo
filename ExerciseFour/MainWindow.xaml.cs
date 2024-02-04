using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace ExerciseFour
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // Заполняем выпадающий список с годами
            for (int year = DateTime.Now.Year; year >= 1900; year--)
            {
                yearComboBox.Items.Add(year);
            }

        }

        private void ComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (sender == yearComboBox)
            {
                UpdateMonthComboBox();
                UpdateDayComboBox();
            }
            else if (sender == monthComboBox)
            {
                UpdateDayComboBox();
            }

            // Активируем следующий выпадающий список
            if (sender == yearComboBox)
            {
                monthComboBox.IsEnabled = true;
            }
            else if (sender == monthComboBox)
            {
                dayComboBox.IsEnabled = true;
            }
            else if (sender == dayComboBox)
            {
                dayComboBox.IsEnabled = true;
            }
        }

        private void UpdateMonthComboBox()
        {
            monthComboBox.Items.Clear();

            if (yearComboBox.SelectedItem != null)
            {
                int selectedYear = (int)yearComboBox.SelectedItem;

                for (int month = 1; month <= 12; month++)
                {
                    DateTimeFormatInfo info = DateTimeFormatInfo.GetInstance(null);
                    string monthName = info.GetMonthName(month);

                    monthComboBox.Items.Add(new ComboBoxItem { Content = monthName, Tag = month });
                }
            }
        }

        private void UpdateDayComboBox()
        {
            dayComboBox.Items.Clear();

            if (yearComboBox.SelectedItem != null && monthComboBox.SelectedItem != null)
            {
                int selectedYear = (int)yearComboBox.SelectedItem;
                int selectedMonth = (int)((ComboBoxItem)monthComboBox.SelectedItem).Tag;

                int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);

                for (int day = 1; day <= daysInMonth; day++)
                {
                    dayComboBox.Items.Add(day);
                }
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные значения из выпадающих списков
            int selectedYear = (int)yearComboBox.SelectedItem;
            int selectedMonth = (int)((ComboBoxItem)monthComboBox.SelectedItem).Tag;
            int selectedDay = (int)dayComboBox.SelectedItem;

            // Создаем объект DateTime с выбранной датой
            DateTime selectedDate = new DateTime(selectedYear, selectedMonth, selectedDay);

            // Вычисляем разницу между выбранной датой и текущим моментом
            TimeSpan difference = DateTime.Now - selectedDate;

            // Выводим результат
            resultTextBlock.Text = $"Прошло лет: {difference.Days / 365}, месяцев: {difference.Days / 30}, дней: {difference.Days}";
        }
    }
}