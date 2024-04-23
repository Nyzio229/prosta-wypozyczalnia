using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentCarClient;
using RentCarClient.ServiceReference1;
using RentCarLibrary;
using System;
using System.IO;
using System.Linq;
using System.Configuration;

namespace RentCarClient.Tests {
    [TestClass]
    public class MainWindowTests {
        [TestMethod]
        public void RentCar_WhenCarIsAvailable_ShouldRentCar() {
            var mainWindow = new MainWindow();
            var selectedCar = new Car { Id = "1", Make = "Toyota", Model = "Corolla", IsRented = "false" };
            var carsFilePath = ConfigurationManager.AppSettings["carsDataBasePath"];
            //mainWindow.rentBox.SelectedItem = selectedCar;
            // Act
            mainWindow.rentButton_Click(null, null);

            // Assert
            var updatedCars = mainWindow.LoadCarsFromFile(carsFilePath);
            var rentedCar = updatedCars.FirstOrDefault(c => c.Id == selectedCar.Id);
            Assert.IsNotNull(rentedCar);
            Assert.AreEqual("false", rentedCar.IsRented);
        }

        [TestMethod]
        public void CancelRent_WhenCarIsRented_ShouldReturnCar() {
            var mainWindow = new MainWindow();
            var carsFilePath = ConfigurationManager.AppSettings["carsDataBasePath"];
            var selectedCar = new Car { Id = "1", Make = "Toyota", Model = "Corolla", IsRented = "true" };
            //mainWindow.rentedList.SelectedItem = selectedCar;

            // Act
            mainWindow.cancelRentBt_Click(null, null);

            // Assert
            var updatedCars = mainWindow.LoadCarsFromFile(carsFilePath);
            var returnedCar = updatedCars.FirstOrDefault(c => c.Id == selectedCar.Id);
            Assert.IsNotNull(returnedCar);
            Assert.AreEqual("false", returnedCar.IsRented);
        }

        [TestMethod]
        public void LoadCarsFromCsv_WhenFileExists_ShouldReturnListOfCars() {
            // Arrange
            var mainWindow = new MainWindow();
            var carsFilePath = ConfigurationManager.AppSettings["carsDataBasePath"];

            // Act
            var cars = mainWindow.LoadCarsFromFile(carsFilePath);

            // Assert
            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count > 0);
        }

    }
}