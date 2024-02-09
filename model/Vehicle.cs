using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.model
{
    public class Vehicle
    {
        
        #region getter setter
        private int vehicleId;
        private string make;
        private string model;
        private int year;
        private decimal dailyRate;
        private string status;
        private int passengerCapacity;
        private int engineCapacity;

        public int VehicleId
        {
            get { return vehicleId; }
            set { vehicleId = value; }
        }
        public string Make
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public decimal DailyRate
        {
            get { return dailyRate; }
            set { dailyRate = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public int PassengerCapacity
        {
            get { return passengerCapacity; }
            set { passengerCapacity = value; }
        }
        public int EngineCapacity
        {
            get { return engineCapacity; }
            set { engineCapacity = value; }
        }

        public Lease lease { get; internal set; }
        #endregion
        #region
        public Vehicle()
        {

        }
        public Vehicle(int _vehicleid, string _make , string _model, int _year, decimal _dailyRate, string _status, int _passengerCapacity, int _engineCapacity )
        {
            VehicleId = _vehicleid;
            Make = _make;
            Model = _model;
            Year = _year;
            DailyRate = _dailyRate;
            Status = _status;
            PassengerCapacity = _passengerCapacity;
            EngineCapacity = _engineCapacity;

        }
        #endregion

        public override string ToString()
        {
            return $"VehicleID::{VehicleId} Make::{Make} Model:: {Model} Year::{Year} " +
                $"DailyRate:: {DailyRate} Status :: {Status} PassengerCapacity:: {PassengerCapacity} " +
                $"EngineCapacity::{EngineCapacity}";
        }


    }
}
