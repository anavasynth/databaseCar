using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
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
using System.Xml.Serialization;

namespace Database
{
    public abstract class Vehicle
    {
        protected string vehicleType;
        protected string brand;
        protected string model;
        protected string color;
        protected int year;
        protected double mileage;

        protected string fuel;
        protected string gearbox;
        protected string driveType;
        protected double power;

        public Vehicle(string vehicleType, string brand, string model, string color, int year, double mileage, string fuel, string gearbox, string driveType, double power)
        {
            this.vehicleType = vehicleType;
            this.brand = brand;
            this.model = model;
            this.color = color;
            this.year = year;
            this.mileage = mileage;
            this.fuel = fuel;
            this.gearbox = gearbox;
            this.driveType = driveType;
            this.power = power;
        }

        public string VehicleType
        {
            get { return vehicleType; }
            set { vehicleType = value; }
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Mileage
        {
            get { return mileage; }
            set { mileage = value; }
        }

        public string Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public string Gearbox
        {
            get { return gearbox; }
            set { gearbox = value; }
        }

        public string DriveType
        {
            get { return driveType; }
            set { driveType = value; }
        }

        public double Power
        {
            get { return power; }
            set { power = value; }
        }

        public abstract string GetVehicleInfo();

        public override string ToString()
        {
            return GetVehicleInfo();
        }
    }

    public class Car : Vehicle
    {
        public Car(string vehicleType, string brand, string model, string color, int year, double mileage, string fuel,
            string gearbox, string driveType, double power)
            : base(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power)
        {
        }

        public override string GetVehicleInfo()
        {
            return $"Тип транспорту: {VehicleType}, {Year} {Brand} {Model}, Колір: {Color},\nПробіг: {Mileage} тис. км, Паливо: {Fuel}, КПП: {Gearbox}, Тип приводу: {DriveType}, Потужність: {Power} кВт";
        }
    }

    public class Lorry : Vehicle
    {
        private string numberOfAxles;
        private double payloadCapacity;
        private string wheelFormula;

        public Lorry(string vehicleType, string brand, string model, string color, int year, double mileage, string fuel,
            string gearbox, string driveType, double power, string numberOfAxles, double payloadCapacity, string wheelFormula)
            : base(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power)
        {
            this.numberOfAxles = numberOfAxles;
            this.payloadCapacity = payloadCapacity;
            this.wheelFormula = wheelFormula;
        }

        public string NumberOfAxles
        {
            get { return numberOfAxles; }
            set { numberOfAxles = value; }
        }

        public double PayloadCapacity
        {
            get { return payloadCapacity; }
            set { payloadCapacity = value; }
        }

        public string WheelFormula
        {
            get { return wheelFormula; }
            set { wheelFormula = value; }
        }

        public override string GetVehicleInfo()
        {
            return $"Тип транспорту: {VehicleType}, {Year} {Brand} {Model}, Колір: {Color},\nПробіг: {Mileage} тис. км, Паливо: {Fuel}, КПП: {Gearbox}, Тип приводу: {DriveType}, Потужність: {Power} кВт" +
                   $", Кількість осей: {NumberOfAxles}, Вантажопідйомність: {PayloadCapacity} т, Колісна формула: {WheelFormula}";
        }
    }

    public interface IVehicleDatabase
    {
        List<Vehicle> SearchCarsByBrand(string brand);
        List<Vehicle> SearchCarsByFuel(string fuel);
        List<Vehicle> SearchCarsByType(string vehicleType);
        List<Vehicle> SearchCarsByYearRange(int startYear, int endYear);
        List<Vehicle> SearchCarsByMileageRange(double startMileage, double endMileage);
        List<Vehicle> SearchSportsCarsByPowerInKW(double minPowerInKW);
    }

    public class CarDatabase : IVehicleDatabase
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        private string filePath;

        public CarDatabase(string filePath)
        {
            this.filePath = filePath;
            LoadData();
        }

        public void AddVehicle(Vehicle vehicle)
        {
            vehicles.Add(vehicle);
            SaveData();
        }

        public void RemoveVehicle(Vehicle vehicle)
        {
            vehicles.Remove(vehicle);
            SaveData();
        }

        public void SortCarsByYear(bool ascending = true)
        {
            if (ascending)
            {
                vehicles.Sort((car1, car2) => car1.Year.CompareTo(car2.Year));
            }
            else
            {
                vehicles.Sort((car1, car2) => car2.Year.CompareTo(car1.Year));
            }
        }

        public void SortCarsByMileage(bool ascending = true)
        {
            if (ascending)
            {
                vehicles.Sort((car1, car2) => car1.Mileage.CompareTo(car2.Mileage));
            }
            else
            {
                vehicles.Sort((car1, car2) => car2.Mileage.CompareTo(car1.Mileage));
            }
        }

        public List<Vehicle> SearchCarsByBrand(string brand)
        {
            return vehicles.Where(car => car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> SearchCarsByFuel(string fuel)
        {
            return vehicles.Where(car => car.Fuel.Equals(fuel, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> SearchCarsByType(string vehicleType)
        {
            return vehicles.Where(car => car.VehicleType.Equals(vehicleType, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Vehicle> SearchCarsByYearRange(int startYear, int endYear)
        {
            return vehicles.FindAll(car => car.Year >= startYear && car.Year <= endYear);
        }

        public List<Vehicle> SearchCarsByMileageRange(double startMileage, double endMileage)
        {
            return vehicles.Where(car => car.Mileage >= startMileage && car.Mileage <= endMileage).ToList();
        }

        public List<Vehicle> SearchSportsCarsByPowerInKW(double minPowerInKW)
        {
            return vehicles.Where(car => car is Car && car.Power >= minPowerInKW).ToList();
        }

        public void EditVehicle(Vehicle oldVehicle, Vehicle newVehicle)
        {
            int index = vehicles.IndexOf(oldVehicle);
            if (index != -1)
            {
                vehicles[index] = newVehicle;
                SaveData();
            }
        }
        public List<Vehicle> GetAllVehicles()
        {
            return vehicles;
        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 13)
                    {
                        string vehicleType = data[0].Trim();
                        string brand = data[1].Trim();
                        string model = data[2].Trim();
                        string color = data[3].Trim();
                        int year = Convert.ToInt32(data[4].Trim());
                        double mileage = Convert.ToDouble(data[5].Trim());
                        string fuel = data[6].Trim();
                        string gearbox = data[7].Trim();
                        string driveType = data[8].Trim();
                        double power = Convert.ToDouble(data[9].Trim());
                        string numberOfAxles = data[10].Trim();
                        double payloadCapacity = Convert.ToDouble(data[11].Trim());
                        string wheelFormula = data[12].Trim();

                        if (vehicleType == "Легковий")
                        {
                            Car car = new Car(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power);
                            vehicles.Add(car);
                        }
                        else if (vehicleType == "Вантажівка")
                        {
                            Lorry lorry = new Lorry(vehicleType, brand, model, color, year, mileage, fuel, gearbox, driveType, power, numberOfAxles, payloadCapacity, wheelFormula);
                            vehicles.Add(lorry);
                        }
                    }
                }
            }
        }

        private void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Vehicle vehicle in vehicles)
                {
                    if (vehicle is Car car)
                    {
                        writer.WriteLine($"Легковий, {car.Brand}, {car.Model}, {car.Color}, {car.Year}, {car.Mileage}, {car.Fuel}, {car.Gearbox}, {car.DriveType}, {car.Power}, 0, 0, N/A");
                    }
                    else if (vehicle is Lorry lorry)
                    {
                        writer.WriteLine($"Вантажівка, {lorry.Brand}, {lorry.Model}, {lorry.Color}, {lorry.Year}, {lorry.Mileage}, {lorry.Fuel}, {lorry.Gearbox}, {lorry.DriveType}, {lorry.Power}, {lorry.NumberOfAxles}, {lorry.PayloadCapacity}, {lorry.WheelFormula}");
                    }
                }
            }
        }
    }

        public partial class MainWindow : Window
        {
            private CarDatabase carDatabase;
            private ObservableCollection<Vehicle> carsCollection;
            public MainWindow()
            {

                InitializeComponent();
                carDatabase = new CarDatabase("carData.txt");
                carsCollection = new ObservableCollection<Vehicle>(carDatabase.GetAllVehicles());


                ImageBrush imageBrush = new ImageBrush();
                imageBrush.ImageSource = new System.Windows.Media.Imaging.BitmapImage(new Uri("C:\\Users\\gonch\\Downloads\\camar.jpg"));
                this.Background = imageBrush;
            }


            private void AddButton_Click(object sender, RoutedEventArgs e)
            {
                AddWin addWindow = new AddWin();
                addWindow.Show();
                Close();
            }

            private void ShowButton__Click(object sender, RoutedEventArgs e)
            {
                ShowWindow showWindow = new ShowWindow();
                showWindow.Show();
                Close();
            }

            private void EditButton_Click(object sender, RoutedEventArgs e)
            {
                EditWindow editWindow = new EditWindow();
                editWindow.Show();
                Close();
            }

            private void DeleteButton_Click(object sender, RoutedEventArgs e)
            {
                DeleteWindow deleteWindow = new DeleteWindow();
                deleteWindow.Show();
                Close();
            }

            private void GuideButton_Click(object sender, RoutedEventArgs e)
            {
                GuideWindow guideWindow = new GuideWindow();
                guideWindow.Show();
                Close();
            }

            private void FindCar_Click(object sender, RoutedEventArgs e)
            {
                  string brand = brandTextBox.Text;

                  if (!string.IsNullOrEmpty(brand))
                  {
                      List<Vehicle> searchResults = carDatabase.SearchCarsByBrand(brand);
                      searchResultListView.ItemsSource = searchResults;
                  }

        }
        private void FindElectroCar_Click(object sender, RoutedEventArgs e)
        {
            string fuel = "Електро";

            if (!string.IsNullOrEmpty(fuel))
            {
                List<Vehicle> searchResults = carDatabase.SearchCarsByFuel(fuel);
                searchResultListView.ItemsSource = searchResults;
            }
        }

        private void FindCarByYearRange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int startYear, endYear;
                int currentYear = DateTime.Now.Year;
                if (int.TryParse(startYearT.Text, out startYear) && int.TryParse(endYearT.Text, out endYear))
                {
                    if (startYear < 1900 || startYear > currentYear || endYear < 1900 || endYear > currentYear)
                    {
                        MessageBox.Show($"Введено некоректний рік випуску. Рік має бути від 1900 до {currentYear}.");
                    }
                    else if (startYear <= endYear)
                    {
                        List<Vehicle> searchResults = carDatabase.SearchCarsByYearRange(startYear, endYear);
                        searchResultListView.ItemsSource = searchResults;
                    }
                    else
                    {
                        MessageBox.Show("Початковий рік не може бути більшим за кінцевий рік.");
                    }
                }
                else
                {
                    MessageBox.Show("Невірний формат введеного року. Будь ласка, введіть ціле число.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message);
            }
        }

        private void FindCarByMileageRange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double startMileage, endMileage;
                if (double.TryParse(startMileageT.Text, out startMileage) && double.TryParse(endMileageT.Text, out endMileage))
                {
                    if (startMileage <= 0 || endMileage <= 0)
                    {
                        MessageBox.Show("Пробіг має бути більше за нуль.");
                        return;
                    }

                    if (startMileage > endMileage)
                    {
                        MessageBox.Show("Початковий пробіг не може бути більшим за кінцевий.");
                        return;
                    }

                    List<Vehicle> searchResults = carDatabase.SearchCarsByMileageRange(startMileage, endMileage);
                    searchResultListView.ItemsSource = searchResults;
                }
                else
                {
                    MessageBox.Show("Невірний формат введеного пробігу. Будь ласка, введіть числове значення.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message);
            }
        }

        private void SearchSportsCarsByPower_Click(object sender, RoutedEventArgs e)
        {
            double minPowerInKW = 300;

            List<Vehicle> searchResults = carDatabase.SearchSportsCarsByPowerInKW(minPowerInKW);
            searchResultListView.ItemsSource = searchResults;
        }

    }
}
