using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using RentCarLibrary;
using System.ServiceModel;

namespace RentCarService {
    public partial class RentCarService : ServiceBase {
        private ServiceHost _serviceHost = null;
        public RentCarService() {
            InitializeComponent();
        }

        protected override void OnStart(string[] args) {
            if(_serviceHost != null) {
                _serviceHost.Close();
            }

            _serviceHost = new ServiceHost(typeof(RentCarService));
            _serviceHost.Open();
        }

        protected override void OnStop() {
            if(_serviceHost != null) {
                _serviceHost.Close();
                _serviceHost = null;
            }
        }
    }
}
