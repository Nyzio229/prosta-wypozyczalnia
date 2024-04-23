using Microsoft.VisualStudio.TestTools.UnitTesting;
using RentCarLibrary;
using System;
using System.Configuration;
using System.IO;
using static System.Net.WebRequestMethods;

namespace RentCarLibraryTests {
    [TestClass]
    public class CarRentalServiceTests {
       
        //[TestMethod]
        //public void RentCar_WhenCarIsAvailable_ShouldRentCar() {
        //    var service = new CarRentalService();
        //    var availableCarId = "2";
        //    var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
        //    service._carsDatabasePath = dbFile;

        //    // Act
        //    var result = service.RentCar(availableCarId);

        //    // Assert
        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        public void RentCar_WhenCarIsAlreadyRented_ShouldNotRentCar() {
            // Arrange
            var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
            var service = new CarRentalService();
            var rentedCarId = "456";

            // Act
            var result = service.RentCar(rentedCarId);

            // Assert
            Assert.IsFalse(result);
        }

        //[TestMethod]
        //public void ReturnCar_WhenCarIsRented_ShouldReturnCar() {
        //    // Arrange
        //    var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
        //    var service = new CarRentalService();
        //    var rentedCarId = "4";
        //    service._carsDatabasePath = dbFile;

        //    // Act
        //    var result = service.ReturnCar(rentedCarId);

        //    // Assert
        //    Assert.IsTrue(result);
        //}

        [TestMethod]
        public void ReturnCar_WhenCarIsNotRented_ShouldNotReturnCar() {
            // Arrange
            var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
            var service = new CarRentalService();
            var availableCarId = "123";

            // Act
            var result = service.ReturnCar(availableCarId);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoadCarsFromCsv_WhenFileExists_ShouldLoadCars() {
            // Arrange
            var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
            var service = new CarRentalService();

            // Act
            var cars = service.LoadCarsFromCsv();

            // Assert
            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count > 0);
        }

        [TestMethod]
        public void LoadCarsFromCsv_WhenFileDoesNotExist_ShouldThrowFileNotFoundException() {
            // Arrange
            var dbFile = ConfigurationManager.AppSettings["carsDataBasePath"];
            var service = new CarRentalService();
            service._carsDatabasePath = "NonExistentFile.csv";

            // Act & Assert
            Assert.ThrowsException<FileNotFoundException>(() => service.LoadCarsFromCsv());
        }
    }
}
