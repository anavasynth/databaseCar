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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private CarDatabase carDatabase;
        private ObservableCollection<Vehicle> carsCollection;
        public EditWindow()
        {
            InitializeComponent();
            carDatabase = new CarDatabase("carData.txt");
            carsCollection = new ObservableCollection<Vehicle>(carDatabase.GetAllVehicles());
            carListView.ItemsSource = carsCollection;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
          if (carListView.SelectedItem != null && CheckValues())
            {
                
                if (carListView.SelectedItem is Car selectedCar)
                {
                    string vehicleType = comboBoxType.Text;
                    string brand = brandTextBox.Text;
                    string model = modelTextBox.Text;
                    string color = colorTextBox.Text;
                    int year = int.Parse(yearTextBox.Text);
                    double mileage = double.Parse(mileageTextBox.Text);
                    string fuel = fuelTextBox.Text;
                    string gearbox = gearboxComboBox.Text;
                    string driveType = driveTypeComboBox.Text;
                    double power = double.Parse(powerTextBox.Text);

                    Car newCar = new Car(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power);

                    carDatabase.EditVehicle(selectedCar, newCar);

                    int selectedIndex = carListView.SelectedIndex;
                    carsCollection[selectedIndex] = newCar;

                    comboBoxType.SelectedItem = null;
                    brandTextBox.Clear();
                    modelTextBox.Clear();
                    colorTextBox.Clear();
                    yearTextBox.Clear();
                    mileageTextBox.Clear();
                    fuelTextBox.SelectedItem = null;
                    gearboxComboBox.SelectedItem = null;
                    driveTypeComboBox.SelectedItem = null;
                    powerTextBox.Clear();
                }
                else if (carListView.SelectedItem is Lorry selectedLorry)
                {
                    string vehicleType = comboBoxType.Text;
                    string brand = brandTextBox.Text;
                    string model = modelTextBox.Text;
                    string color = colorTextBox.Text;
                    int year = int.Parse(yearTextBox.Text);
                    double mileage = double.Parse(mileageTextBox.Text);
                    string fuel = fuelTextBox.Text;
                    string gearbox = gearboxComboBox.Text;
                    string driveType = driveTypeComboBox.Text;
                    double power = double.Parse(powerTextBox.Text);
                    string numberOfAxles = numberOfAxlesComboBox.Text;
                    double payloadCapacity = double.Parse(payloadCapacityTextBox.Text);
                    string wheelFormula = wheelFormulaComboBox.Text;
     
                    Lorry newLorry = new Lorry(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power, numberOfAxles, payloadCapacity, wheelFormula);
                    
                    carDatabase.EditVehicle(selectedLorry, newLorry);

                    int selectedIndex = carListView.SelectedIndex;
                    carsCollection[selectedIndex] = newLorry;

                    comboBoxType.SelectedItem = null;
                    brandTextBox.Clear();
                    modelTextBox.Clear();
                    colorTextBox.Clear();
                    yearTextBox.Clear();
                    mileageTextBox.Clear();
                    fuelTextBox.SelectedItem = null;
                    gearboxComboBox.SelectedItem = null;
                    driveTypeComboBox.SelectedItem = null;
                    powerTextBox.Clear();
                    numberOfAxlesComboBox.SelectedItem = null;
                    payloadCapacityTextBox.Clear();
                    wheelFormulaComboBox.SelectedItem = null;
                }
            }
        }

        private bool CheckValues()
        {
            bool pass = true;

            if (string.IsNullOrWhiteSpace(comboBoxType.Text))
            {
                MessageBox.Show("Поле \"Тип транспорту\" має бути заповненим");
                pass = false;
            }
            else if (string.IsNullOrWhiteSpace(brandTextBox.Text))
            {
                MessageBox.Show("Поле \"Марка\" не може бути порожнім.");
                pass = false;
            }
            else if (string.IsNullOrWhiteSpace(modelTextBox.Text))
            {
                MessageBox.Show("Поле \"Модель\" має бути заповненим");
                pass = false;
            }
            else if (string.IsNullOrWhiteSpace(colorTextBox.Text))
            {
                MessageBox.Show("Поле \"Колір\" має бути заповненим");
                pass = false;
            }
            // перевірка року випуску
            if (string.IsNullOrWhiteSpace(yearTextBox.Text))
            {
                MessageBox.Show("Поле \"Рік\" має бути заповненим");
                pass = false;
            }
            else if (yearTextBox.Text != "")
            {
                try
                {
                    int year = int.Parse(yearTextBox.Text);
                    int currentYear = DateTime.Now.Year;

                    if (year < 1900 || year > currentYear)
                    {
                        MessageBox.Show($"Введено некоректний рік випуску. Рік має бути від 1900 до {currentYear}.");
                        pass = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Некоректний формат року випуску. Будь ласка, введіть число.");
                    pass = false;
                }
            }

            if (string.IsNullOrWhiteSpace(mileageTextBox.Text))
            {
                MessageBox.Show("Поле \"Пробіг\" має бути заповненим");
                pass = false;
            }
            else if (mileageTextBox.Text != "")
            {
                try
                {
                    double milage = double.Parse(mileageTextBox.Text);

                    if (milage < 0)
                    {
                        MessageBox.Show($"Введено некоректний пробіг");
                        pass = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введено некоректний пробіг");
                    pass = false;
                }
            }

            string vehicleType = comboBoxType.Text;

            if (vehicleType == "Вантажівка")
            {

                if (string.IsNullOrWhiteSpace(numberOfAxlesComboBox.Text))
                {
                    MessageBox.Show("Поле \"Кількість осей\" має бути заповненим");
                    pass = false;
                }
                else if (string.IsNullOrWhiteSpace(wheelFormulaComboBox.Text))
                {
                    MessageBox.Show("Поле \"Колісна формула\" має бути заповненим");
                    pass = false;
                }

                if (string.IsNullOrWhiteSpace(payloadCapacityTextBox.Text))
                {
                    MessageBox.Show("Поле \"Вантажопідйомність\" не може бути порожнім.");
                    pass = false;
                }
                else if (payloadCapacityTextBox.Text != "")
                {
                    try
                    {
                        double payloadCapacity = double.Parse(payloadCapacityTextBox.Text);

                        if (payloadCapacity < 0)
                        {
                            MessageBox.Show($"Введено некоректну вантожопідйомність");
                            pass = false;
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Введено некоректне значення");
                        pass = false;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(fuelTextBox.Text))
            {
                fuelTextBox.Text = "Не вказано";
            }
            if (string.IsNullOrWhiteSpace(gearboxComboBox.Text))
            {
                gearboxComboBox.Text = "Не вказано";
            }
            if (string.IsNullOrWhiteSpace(driveTypeComboBox.Text))
            {
                driveTypeComboBox.Text = "Не вказано";
            }

            if (string.IsNullOrWhiteSpace(powerTextBox.Text))
            {
                powerTextBox.Text = "0";
            }
            else if (powerTextBox.Text != "")
            {
                double power;
                try
                {
                    power = double.Parse(powerTextBox.Text);
                    if (power < 0)
                    {
                        MessageBox.Show("Введено некоректну потужність");
                        pass = false;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введено некоректну потужність");
                    pass = false;
                }
            }

            return pass;
        }

        private void DisplayCarData(Car vehicle)
        {
            comboBoxType.Text = vehicle.VehicleType;
            brandTextBox.Text = vehicle.Brand;
            modelTextBox.Text = vehicle.Model;
            colorTextBox.Text = vehicle.Color;
            yearTextBox.Text = vehicle.Year.ToString();
            mileageTextBox.Text = vehicle.Mileage.ToString();
            fuelTextBox.Text = vehicle.Fuel;
            gearboxComboBox.Text = vehicle.Gearbox;
            driveTypeComboBox.Text = vehicle.DriveType;
            powerTextBox.Text = vehicle.Power.ToString();
        }

        private void DisplayLorryData(Lorry vehicle)
        {
            comboBoxType.Text = vehicle.VehicleType;
            brandTextBox.Text = vehicle.Brand;
            modelTextBox.Text = vehicle.Model;
            colorTextBox.Text = vehicle.Color;
            yearTextBox.Text = vehicle.Year.ToString();
            mileageTextBox.Text = vehicle.Mileage.ToString();
            fuelTextBox.Text = vehicle.Fuel;
            gearboxComboBox.Text = vehicle.Gearbox;
            driveTypeComboBox.Text = vehicle.DriveType;
            powerTextBox.Text = vehicle.Power.ToString();
            numberOfAxlesComboBox.Text = vehicle.NumberOfAxles;
            payloadCapacityTextBox.Text = vehicle.PayloadCapacity.ToString();
            wheelFormulaComboBox.Text = vehicle.WheelFormula;
        }

        private void carListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string vehicleType = comboBoxType.Text;
            if (carListView.SelectedItem != null)
            {
                if (carListView.SelectedItem is Car)
                {
                    Car selectedCar = (Car)carListView.SelectedItem;
                    DisplayCarData(selectedCar);
                }
                else if (carListView.SelectedItem is Lorry)
                {
                    Lorry selectedLorry = (Lorry)carListView.SelectedItem;
                    DisplayLorryData(selectedLorry);
                }
            }
        }

    }
}
