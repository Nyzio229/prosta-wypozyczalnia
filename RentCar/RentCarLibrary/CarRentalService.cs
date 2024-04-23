using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static RentCarLibrary.Car;
using System.Configuration;
using System.Globalization;

namespace RentCarLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CarRentalService : ICarRentalService {
        //public string GetData(int value) {
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite) {
        //    if (composite == null) {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue) {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public string _carsDatabasePath = ConfigurationManager.AppSettings.Get("carsDataBasePath");
        private const string EventLogSource = "WypozyczalniaSamochodowSource";
        private const string EventLogName = "Wypozyczalnia Aut";

        //public CarRentalService(string carsDatabasePath) {
        //    _carsDatabasePath = carsDatabasePath;
        //}
        public CarRentalService() {
            if (!EventLog.SourceExists(EventLogSource)) {
                EventLog.CreateEventSource(EventLogSource, EventLogName);
            }
        }

        public bool RentCar(string carId) {
            try {
                var cars = LoadCarsFromCsv();
                var car = cars.FirstOrDefault(c => c.Id == carId && (c.IsRented=="false"));

                if (car != null) {
                    car.IsRented = "true";
                    SaveCarsToCsv(cars);
                    LogEvent($"Samochód o ID {carId} jest wypożyczony.");
                    return true;
                }
                else {
                    LogEvent($"Samochód o ID {carId} jest już wypożyczony albo nie istnieje.");
                    return false;
                }
            }
            catch (Exception ex) {
                LogEvent($"Error renting car with ID {carId}: {ex.Message}");
                return false;
            }
        }

        public bool ReturnCar(string carId) {
            try {
                var cars = LoadCarsFromCsv();

                // Znajdź samochód, którego wypożyczenie chcesz anulować
                var car = cars.FirstOrDefault(c => c.Id == carId && (c.IsRented == "true"));

                if (car != null) {
                    // Zmień wartość pola IsRented na false
                    car.IsRented = "false";

                    // Zapisz zmienioną listę samochodów z powrotem do pliku CSV
                    SaveCarsToCsv(cars);

                    LogEvent($"Dla samochodu o ID {carId} anulowano rezerwacje.");
                    return true;
                }
                else {
                    LogEvent($"Samochód o ID {carId} nie jest obecnie wypożyczony albo nie istniej.");
                    return false;
                }
            }
            catch (Exception ex) {
                LogEvent($"Error canceling car rental with ID {carId}: {ex.Message}");
                return false;
            }
        }

        public List<Car> GetCars() {
            try {
                return LoadCarsFromCsv();
            }
            catch (Exception ex) {
                LogEvent($"Error getting cars: {ex.Message}");
                return null;
            }
        }

        public List<Car> LoadCarsFromCsv() {
            var cars = new List<Car>();
            using (var reader = new StreamReader(_carsDatabasePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { HasHeaderRecord = false, MissingFieldFound = null})) {
                // Ignoruj brakujące pola podczas odczytu danych z pliku CSV
                //csv.Configuration.MissingFieldFound.Equals(null);
                //csv.Configuration.MissingFieldFound.Equals(true);
                //csv.Context.RegisterClassMap<CarMap>();

                cars = csv.GetRecords<Car>().ToList();
            }
            return cars;
        }

        public void SaveCarsToCsv(List<Car> cars) {
            //using (var writer = new StreamWriter(_carsDatabasePath))
            //using (var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture) { HasHeaderRecord = false, MissingFieldFound = null })) {
            //    csv.WriteRecords(cars);
            //}
            using (var writer = new StreamWriter(_carsDatabasePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                csv.WriteRecords(cars);
            }

        }

        private void LogEvent(string message) {
            EventLog.WriteEntry(EventLogSource, message, EventLogEntryType.Information);
        }
    }
}
