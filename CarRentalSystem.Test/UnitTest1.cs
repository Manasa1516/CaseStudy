using CarRentalSystem;
using CarRentalSystem.Service;
using CarRentalSystem.Repository;
using CarRentalSystem.Exceptions;
using CarRentalSystem.model;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using CarRentalSystem.model;
namespace CarRentalSystemTest
{
    public class Tests
    {
        CarLeaseRepository _carRentalService;

        [SetUp]
        public void Setup()
        {
            _carRentalService = new CarLeaseRepository();
        }
        //Arrange, Act and Assert
        [Test]

        public void IfCarAddedSuccessElseFail()
        {
            Vehicle testVehicle = new Vehicle
            {
                Make = "Suzuki",
                Model = "Ertiga",
                Year = 2022,
                DailyRate = 3000.0m,
                Status = "available",
                PassengerCapacity = 7,
                EngineCapacity = 2000
            };


            int a = _carRentalService.RegisterVehicle(testVehicle);


            Assert.IsTrue(a>0);
        }
        
        [Test]
        public void IfLeaseAddedSuccessElseFail()
        {
            Lease testLease = new Lease
            {
                VehicleId = 1,
                CustomerId = 1,
                TypeL = "MonthlyLease",
                StartDate = ("2024-02-05"),
                EndDate =("2024-04-05")
            };


            int a = _carRentalService.AddLease(testLease);

            Assert.IsTrue(a > 0);
        }
        [Test]
        public void IfLeaseRetrievedSuccessfully()
        {
            int existingLeaseId = 1;

            var retrievedLease = _carRentalService.FindLeaseById(existingLeaseId);

            Assert.IsNotNull(retrievedLease);
        }


        [Test]
        public void FindCustomerById_ThrowsCustomerNotFoundException()
        {

            int nonExistingCustomerId = 100;

            Assert.Throws<CustomerrNotFoundException>(() => _carRentalService.FindCustomerById(nonExistingCustomerId));

        }

        [Test]
        public void FindCarById_ThrowsCarNotFoundException()
        {

            int nonExistingVehicleId = 100;

            Assert.Throws<CarNotFoundException>(() => _carRentalService.FindVehicleById(nonExistingVehicleId));

        }

        [Test]
        public void FindLeaseById_ThrowsLeaseNotFoundException()
        {

            int nonExistingLeaseId = 100;

            Assert.Throws<LeaseNotFoundException>(() => _carRentalService.FindLeaseById(nonExistingLeaseId));

        }



    }
}