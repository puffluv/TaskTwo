using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;

namespace ExerciseFive
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private int seconds;
        private ObservableCollection<string> records;
        public MainWindow()
        {
            InitializeComponent(); 
            InitializeTimer();

            records = new ObservableCollection<string>();
            recordsListBox.ItemsSource = records;
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconds++;
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            if (formatCheckBox.IsChecked == true)
            {
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                timerTextBlock.Text = $"{time.Hours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
            }
            else
            {
                timerTextBlock.Text = seconds.ToString();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            seconds = 0;
            UpdateTimerText();
        }

        private void RecordButton_Click(object sender, RoutedEventArgs e)
        {
            int recordNumber = records.Count + 1;
            records.Add($"Время {recordNumber}: " + timerTextBlock.Text);
        }
    }
}
