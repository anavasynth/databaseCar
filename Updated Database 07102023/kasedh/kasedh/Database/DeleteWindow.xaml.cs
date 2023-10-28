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
    public partial class DeleteWindow : Window
    {
        private CarDatabase carDatabase;
        private ObservableCollection<Vehicle> carsCollection;
        public DeleteWindow()
        {
            InitializeComponent();
            carDatabase = new CarDatabase("carData.txt");
            carsCollection = new ObservableCollection<Vehicle>(carDatabase.GetAllVehicles());
            carListViewDelete.ItemsSource = carsCollection;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {       
            if (carListViewDelete.SelectedItem != null)
            {
                Vehicle selectedCar = (Vehicle)carListViewDelete.SelectedItem;
                carDatabase.RemoveVehicle(selectedCar); // Видалення автомобіля з бази даних
                carsCollection.Remove(selectedCar); // Видалення автомобіля з колекції
            }
            MessageBox.Show("Об'є́кт вилучено");
        }
    }
}
