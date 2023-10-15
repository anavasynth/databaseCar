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
using System.Windows.Shapes;

namespace Database
{
    /// <summary>
    /// Логика взаимодействия для ShowWindow.xaml
    /// </summary>
    public partial class ShowWindow : Window
    {
        private CarDatabase carDatabase;
        private ObservableCollection<Vehicle> carsCollection;
        public ShowWindow()
        {
            InitializeComponent();

            carDatabase = new CarDatabase("carData.txt");
            carsCollection = new ObservableCollection<Vehicle>(carDatabase.GetAllVehicles());
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {
            carListView.ItemsSource = carsCollection;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            //за роком
            if (comboBoxKey.Text == "Рік" && comboBoxType.Text == "Зростання")
            {
                carDatabase.SortCarsByYear(true);
            }
            else if (comboBoxKey.Text == "Рік" && comboBoxType.Text == "Спадання")
            {
                carDatabase.SortCarsByYear(false);
            }
            else if (comboBoxKey.Text == "Пробіг" && comboBoxType.Text == "Зростання")
            {
                carDatabase.SortCarsByMileage(true);
            }
            else if (comboBoxKey.Text == "Пробіг" && comboBoxType.Text == "Спадання")
            {
                carDatabase.SortCarsByMileage(false);
            }

            carsCollection.Clear();
            List<Vehicle> sortedCars = carDatabase.GetAllVehicles();
            foreach (Vehicle car in sortedCars)
            {
                carsCollection.Add(car);
            }

            string vehicleType = vType.Text;

            if (!string.IsNullOrEmpty(vehicleType) && vehicleType != "Всі")
            {
                List<Vehicle> searchResults = carDatabase.SearchCarsByType(vehicleType);
                carListView.ItemsSource = searchResults;
            }
            else
            {
                carListView.ItemsSource = carsCollection;
            }



        }
    }
}
