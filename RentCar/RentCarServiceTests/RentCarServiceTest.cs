using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RentCarService;
using System.ServiceModel;

namespace RentCarServiceTests {

    // Klasa dziedzicząca od RentCarService, aby umożliwić dostęp do metod chronionych
    public class TestableRentCarService : RentCarService.RentCarService {
        
        public void StartService() {
            base.OnStart(null);
        }

       
        public void StopService() {
            base.OnStop();
        }

        
        public System.ServiceModel.ServiceHost ServiceHost {
            get { return ServiceHost; }
        }
    }

    [TestClass]
    public class RentCarServiceTest {
        [TestMethod]
        public void OnStart_ShouldOpenServiceHost() {
           
            var service = new TestableRentCarService();

           
            service.StartService();

           
            Assert.IsNotNull(service.ServiceHost);
            Assert.IsTrue(service.ServiceHost.State == System.ServiceModel.CommunicationState.Opened);
        }

        [TestMethod]
        public void OnStop_ShouldCloseServiceHost() {
           
            var service = new TestableRentCarService(); 
            service.StartService();

           
            service.StopService(); 

            
            Assert.IsNotNull(service.ServiceHost);
            Assert.IsTrue(service.ServiceHost.State == System.ServiceModel.CommunicationState.Closed);
        }
    }

   
}

