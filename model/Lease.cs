using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.model
{
    public class Lease
    {
        #region getter setter
        private int leaseId;
        private int vehicleId;
        private int customerId;
        private string startDate;
        private string endDate;
        private string typeL;

        public int LeaseId
        {
            get { return leaseId; }
            set { leaseId = value; }
        }
        public int VehicleId
        { 
            get { return vehicleId; } 
            set {  vehicleId = value; } 
        }
        public int CustomerId
        { 
            get { return customerId; } 
            set {  customerId = value; } 
        }
        public string StartDate
        { 
            get { return startDate; } 
            set {  startDate = value; } 
        }
        public string EndDate
        { 
            get { return endDate; } 
            set {  endDate = value; } 
        }
        public string TypeL
        {
            get { return typeL; }
            set { typeL = value; }
        }
        
        #endregion
        public Lease()
        {
            
        }
        public Lease(int _leaseID,int _vehicleID, int _customerID, string _startDate, string _endDate, string _typeL)
        {
            LeaseId = _leaseID;
            VehicleId = _vehicleID;
            CustomerId = _customerID;
            StartDate = _startDate;
            EndDate = _endDate;
            TypeL = _typeL;

        }
        public override string ToString()
        {
            return $"LeaseID::{LeaseId}\n VehicleId::{VehicleId}\n CustomerId:: {CustomerId}\n StartDate::{StartDate}\n " +
                $"EndDate:: {EndDate}\n Typel::{TypeL}\n";
        }
    }
}
