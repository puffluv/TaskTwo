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

namespace ExerciseThree
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Planets { get; set; }
        public MainWindow()
        {
            InitializePlanets();
            DataContext = this;
            InitializeComponent();
        }
        private void InitializePlanets()
        {
            // Инициализация списка планет
            Planets = new ObservableCollection<string>
            {
                "Меркурий", "Венера", "Земля", "Марс", "Юпитер", "Сатурн", "Уран", "Нептун"
            };
        }

        private void OnPlanetSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Обработка события выбора планеты
            if (PlanetListBox.SelectedItem != null)
            {
                string selectedPlanet = PlanetListBox.SelectedItem.ToString();
                DisplayPlanetInfo(selectedPlanet);
            }
        }
        private void DisplayPlanetInfo(string planet)
        {
            // Краткая информация о выбранной планете
            switch (planet)
            {
                case "Меркурий":
                    InfoTextBox.Text = "Меркурий - ближайшая к Солнцу планета солнечной системы.";
                    break;
                case "Венера":
                    InfoTextBox.Text = "Венера - вторая планета от Солнца, схожа по размерам с Землей.";
                    break;
                case "Земля":
                    InfoTextBox.Text = "Земля - третья планета от Солнца, единственная известная планета, обладающая жизнью.";
                    break;
                case "Марс":
                    InfoTextBox.Text = "Марс - четвёртая планета от Солнца, называемая \"Красной планетой\".";
                    break;
                case "Юпитер":
                    InfoTextBox.Text = "Юпитер - самая крупная планета солнечной системы, газовый гигант.";
                    break;
                case "Сатурн":
                    InfoTextBox.Text = "Сатурн - шестая планета, известная своими кольцами.";
                    break;
                case "Уран":
                    InfoTextBox.Text = "Уран - седьмая планета, наклоненная на бок.";
                    break;
                case "Нептун":
                    InfoTextBox.Text = "Нептун - восьмая и далёкая от Солнца планета.";
                    break;
                default:
                    InfoTextBox.Text = "Информация о планете не доступна.";
                    break;
            }
        }
    }
}
