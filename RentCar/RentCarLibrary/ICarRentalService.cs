using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RentCarLibrary {
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICarRentalService {
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        bool RentCar(string carId);

        [OperationContract]
        bool ReturnCar(string carId);

        [OperationContract]
        List<Car> GetCars();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "RentCarLibrary.ContractType".

    //public class CompositeType {
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }



    //}
    [DataContract]
    public class Car {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string IsRented { get; set; }
    }

    //[DataContract]
    //public class CarMap : ClassMap<Car> {
    //    public CarMap() {
    //        Map(m => m.Id).Index(0);
    //        Map(m => m.Make).Index(1);
    //        Map(m => m.Model).Index(2);
    //        Map(m => m.IsRented).Index(3).TypeConverterOption.BooleanValues(true, true, "1", "0");
    //    }
    //}
}
