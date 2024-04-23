using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.ServiceModel;
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
using RentCarClient.ServiceReference1;
using RentCarLibrary;
using System.Configuration;
using System.IO;
using System.Globalization;
using CsvHelper;
using System.ServiceProcess;

namespace RentCarClient {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        CarRentalServiceClient client = new CarRentalServiceClient();
        private List<Car> cars;
        private ServiceController rentCarServiceController = new ServiceController("RentCarService");
        public MainWindow() {
            InitializeComponent();
            LoadCarsFromCsv();
        }

        public void LoadCarsFromCsv() {
            var carsFilePath = ConfigurationManager.AppSettings["carsDataBasePath"];
            cars = LoadCarsFromFile(carsFilePath);

            rentBox.ItemsSource = cars.Where(car => car.IsRented == "false");
            rentedList.ItemsSource = cars.Where(car => car.IsRented == "true");
        }

        public List<Car> LoadCarsFromFile(string filePath) {
            var cars = new List<Car>();

            try {
                var lines = File.ReadAllLines(filePath).Skip(1);
                foreach (var line in lines) {
                    var fields = line.Split(',');
                    if (fields.Length >= 4) {
                        var car = new Car {
                            Id = fields[0],
                            Make = fields[1],
                            Model = fields[2],
                            IsRented = fields[3]
                        };
                        cars.Add(car);
                    }
                    else {
                        // Obsługa przypadku, gdy linia nie zawiera odpowiedniej liczby pól
                    }
                }
            }
            catch (Exception ex) {
                // Obsługa błędu wczytywania pliku
                MessageBox.Show($"Error loading cars from file: {ex.Message}");
            }

            return cars;
        }

        public void rentButton_Click(object sender, RoutedEventArgs e) {
            var selectedCar = rentBox.SelectedItem as Car;
            if (selectedCar == null) {
                MessageBox.Show("Please select a car to rent.");
                return;
            }

            var fromDateValue = fromDate.SelectedDate ?? DateTime.Now;
            var toDateValue = toDate.SelectedDate ?? fromDateValue.AddDays(1);

            try {
                if (client.RentCar(selectedCar.Id)) {
                    selectedCar.IsRented = "true";
                    rentBox.ItemsSource = cars.Where(car => car.IsRented == "false");
                    rentedList.ItemsSource = cars.Where(car => car.IsRented == "true");
                    MessageBox.Show("Car rented successfully.");
                }
                else {
                    MessageBox.Show("Car is already rented or does not exist.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error renting car: {ex.Message}");
            }
        }

        public void cancelRentBt_Click(object sender, RoutedEventArgs e) {
            var selectedCar = rentedList.SelectedItem as Car;
            if (selectedCar == null) {
                MessageBox.Show("Please select a car to unrent.");
                return;
            }

            var fromDateValue = fromDate.SelectedDate ?? DateTime.Now;
            var toDateValue = toDate.SelectedDate ?? fromDateValue.AddDays(1);

            try {
                if (client.ReturnCar(selectedCar.Id)) {
                    selectedCar.IsRented = "false";
                    rentBox.ItemsSource = cars.Where(car => car.IsRented == "false");
                    rentedList.ItemsSource = cars.Where(car => car.IsRented == "true");
                    MessageBox.Show("Car rental canceled successfully.");
                }
                else {
                    MessageBox.Show("Car is not currently rented or does not exist.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error canceling car rental: {ex.Message}");
            }
        }

        public void refreshButton_Click(object sender, RoutedEventArgs e) {
            LoadCarsFromCsv();
        }

        public void StartRentCarService() {
            try {
                if (rentCarServiceController.Status != ServiceControllerStatus.Running) {
                    rentCarServiceController.Start();
                    rentCarServiceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                    MessageBox.Show("RentCarService started successfully.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error starting RentCarService: {ex.Message}");
            }
        }

        public void StopRentCarService() {
            try {
                if (rentCarServiceController.Status != ServiceControllerStatus.Stopped) {
                    rentCarServiceController.Stop();
                    rentCarServiceController.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10));
                    MessageBox.Show("RentCarService stopped successfully.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"Error stopping RentCarService: {ex.Message}");
            }
        }
        public void Window_Loaded(object sender, RoutedEventArgs e) {
            // Startowanie usługi RentCarService po załadowaniu okna
            StartRentCarService();
        }

        public void Window_Closed(object sender, EventArgs e) {
            // Zatrzymywanie usługi RentCarService po zamknięciu okna
            StopRentCarService();
        }

        public void rentButton_Click(object value1, object value2) {
            throw new NotImplementedException();
        }
    }
}
