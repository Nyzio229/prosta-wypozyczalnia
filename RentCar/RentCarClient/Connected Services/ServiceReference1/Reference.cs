﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCarClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICarRentalService")]
    public interface ICarRentalService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/RentCar", ReplyAction="http://tempuri.org/ICarRentalService/RentCarResponse")]
        bool RentCar(string carId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/RentCar", ReplyAction="http://tempuri.org/ICarRentalService/RentCarResponse")]
        System.Threading.Tasks.Task<bool> RentCarAsync(string carId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/ReturnCar", ReplyAction="http://tempuri.org/ICarRentalService/ReturnCarResponse")]
        bool ReturnCar(string carId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/ReturnCar", ReplyAction="http://tempuri.org/ICarRentalService/ReturnCarResponse")]
        System.Threading.Tasks.Task<bool> ReturnCarAsync(string carId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/GetCars", ReplyAction="http://tempuri.org/ICarRentalService/GetCarsResponse")]
        RentCarLibrary.Car[] GetCars();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICarRentalService/GetCars", ReplyAction="http://tempuri.org/ICarRentalService/GetCarsResponse")]
        System.Threading.Tasks.Task<RentCarLibrary.Car[]> GetCarsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICarRentalServiceChannel : RentCarClient.ServiceReference1.ICarRentalService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CarRentalServiceClient : System.ServiceModel.ClientBase<RentCarClient.ServiceReference1.ICarRentalService>, RentCarClient.ServiceReference1.ICarRentalService {
        
        public CarRentalServiceClient() {
        }
        
        public CarRentalServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CarRentalServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarRentalServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CarRentalServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool RentCar(string carId) {
            return base.Channel.RentCar(carId);
        }
        
        public System.Threading.Tasks.Task<bool> RentCarAsync(string carId) {
            return base.Channel.RentCarAsync(carId);
        }
        
        public bool ReturnCar(string carId) {
            return base.Channel.ReturnCar(carId);
        }
        
        public System.Threading.Tasks.Task<bool> ReturnCarAsync(string carId) {
            return base.Channel.ReturnCarAsync(carId);
        }
        
        public RentCarLibrary.Car[] GetCars() {
            return base.Channel.GetCars();
        }
        
        public System.Threading.Tasks.Task<RentCarLibrary.Car[]> GetCarsAsync() {
            return base.Channel.GetCarsAsync();
        }
    }
}
