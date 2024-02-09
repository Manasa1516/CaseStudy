using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Exceptions;
using CarRentalSystem.model;
using CarRentalSystem.Repository;

namespace CarRentalSystem.Service
{
    internal class CarLeaseService : ICarLeaseService
    {
        readonly ICarLeaseRepository _service;
        public CarLeaseService()
        {
            _service = new CarLeaseRepository();
        }
        #region GetAllVehicles
        public void GetAllVehicles()
        {
            List<Vehicle> allVehicles = _service.GetAllVehicles();
            foreach (Vehicle vehicle in allVehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
        #endregion
        #region GetAllRentedVehicles
        public void GetAllRentedVehicles()
        {
            List<Vehicle> allRentedVehicles = _service.GetAllRentedVehicles();
            foreach (Vehicle vehicle in allRentedVehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
#endregion
        #region FindVehicleById
        public void FindVehicleById()
        {
            try
            {
                Console.WriteLine("Enter VehicleId:");

                if (int.TryParse(Console.ReadLine(), out int vehicleId))
                {
                    DisplayVehicleDetails(_service.FindVehicleById(vehicleId));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for VehicleId.");
                }
            }
            catch (CarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DisplayVehicleDetails(List<Vehicle> vehicles)
        {
            if (vehicles.Count > 0)
            {
                Console.WriteLine("Vehicle found:");
                foreach (Vehicle vehicle in vehicles)
                {
                    Console.WriteLine($"VehicleId: {vehicle.VehicleId}\n Make: {vehicle.Make}\n Model: {vehicle.Model}\n Year: {vehicle.Year}\n " +
                        $"DailyRate: {vehicle.DailyRate}\n Status: {vehicle.Status}\n PassengerCapacity: {vehicle.PassengerCapacity}\n EngineCapacity: {vehicle.EngineCapacity}");
                }
            }
        }
        #endregion
        #region RegisterVehicle
        public void RegisterVehicle()
        {
            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Enter vehicle Make::");
            vehicle.Make = Console.ReadLine();
            Console.WriteLine("Enter Model::");
            vehicle.Model = Console.ReadLine();
            Console.WriteLine("Enter Year::");
            vehicle.Year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter DailyRate::");
            vehicle.DailyRate = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Status::");
            vehicle.Status = Console.ReadLine();
            Console.WriteLine("Enter PassengerCapacity::");
            vehicle.PassengerCapacity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter EngineCapacity::");
            vehicle.EngineCapacity = int.Parse(Console.ReadLine());

            try
            {
                int addVehicleStatus = _service.RegisterVehicle(vehicle);
                if (addVehicleStatus > 0)
                {
                    Console.WriteLine("Registration success");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
#endregion
        #region RemoveVehicle
        public void RemoveVehicle()
        {
            Vehicle vehicle = new Vehicle();
            Console.WriteLine("Enter VehicleId::");
            vehicle.VehicleId = int.Parse(Console.ReadLine());

            try
            {
                int addRemoveVehicleStatus = _service.RemoveVehicle(vehicle);
                if (addRemoveVehicleStatus > 0)
                {
                    Console.WriteLine("Vehicle removal success");
                }
                else
                {
                    Console.WriteLine("Vehicle not found");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
        #endregion
        #region AddCustomer
        public void AddCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter Customer FirstName::");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Customer LastName::");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter Email::");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Enter PhoneNumber::");
            customer.PhoneNumber = Console.ReadLine();

            try
            {
                int addCustomerStatus = _service.AddCustomer(customer);
                if (addCustomerStatus > 0)
                {
                    Console.WriteLine("Customer added successfully");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
        #endregion
        #region RemoveCustomer
        public void RemoveCustomer()
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter CustomerId::");
            customer.CustomerId = int.Parse(Console.ReadLine());

            try
            {
                int addRemoveCustomerStatus = _service.RemoveCustomer(customer);
                if (addRemoveCustomerStatus > 0)
                {
                    Console.WriteLine("Customer removal success");
                }
                else
                {
                    Console.WriteLine("Customer not found");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
        #endregion
        #region GetAllCustomers
        public void GetAllCustomers()
        {
            List<Customer> allCustomers = _service.GetAllCustomers();
            foreach (Customer customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
        }
        #endregion
        #region FindCustomerById
        public void FindCustomersById()
        {
            try
            {
                Console.WriteLine("Enter CustomerId:");

                if (int.TryParse(Console.ReadLine(), out int customerId))
                {
                    DisplayCustomerDetails(_service.FindCustomerById(customerId));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for CustomerId.");
                }
            }
            catch (CustomerrNotFoundException uaex)
            {
                Console.WriteLine($"Message:{uaex.Message}");

            }
        }

        private void DisplayCustomerDetails(List<Customer> customers)
        {
            if (customers.Count > 0)
            {
                Console.WriteLine("Customer found:");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"CustomerId: {customer.CustomerId}\n FirstName: {customer.FirstName}\n LastName: {customer.LastName}\n Email: {customer.Email}\n " +
                        $"PhoneNumber: {customer.PhoneNumber}\n");
                }
            }
            //else
            //{
            //    Console.WriteLine("No customer found with the specified customerId.");
            //}
        }
        #endregion
        #region AddLease
        public void AddLease()
        {
            Lease lease = new Lease();
            Console.WriteLine("Enter VehicleId::");
            lease.VehicleId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CustomerId::");
            lease.CustomerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer StartDate::");
            lease.StartDate = Console.ReadLine();
            Console.WriteLine("Enter Customer EndDate::");
            lease.EndDate = Console.ReadLine();
            Console.WriteLine("Enter TypeL::");
            lease.TypeL = Console.ReadLine();

            try
            {
                int addLeaseStatus = _service.AddLease(lease);
                if (addLeaseStatus > 0)
                {
                    Console.WriteLine("Lease added successfully");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
        #endregion
        #region FindLeaseById
        public void FindLeaseById()
        {
            try
            {
                Console.WriteLine("Enter LeaseId:");

                if (int.TryParse(Console.ReadLine(), out int leaseId))
                {
                    DisplayLeaseDetails(_service.FindLeaseById(leaseId));
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer for LeaseId.");
                }
            }
            catch (LeaseNotFoundException uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }

        private void DisplayLeaseDetails(List<Lease> leases)
        {
            if (leases.Count > 0)
            {
                Console.WriteLine("Lease found:");
                foreach (Lease lease in leases)
                {
                    Console.WriteLine($"LeaseId: {lease.LeaseId}\n VehicleId: {lease.VehicleId}\n CustomerId: {lease.CustomerId}\n StartDate: {lease.StartDate}\n " +
                        $"EndDate: {lease.EndDate}\n TypeL: {lease.TypeL}\n");
                }
            }
            //else
            //{
            //    Console.WriteLine("No lease found with the specified leaseId.");
            //}
        }
        #endregion
        #region GetActiveLeases
        public void GetActiveLeases()
        {
            List<Lease> allActiveLeases = _service.GetActiveLeases();
            foreach (Lease lease in allActiveLeases)
            {
                Console.WriteLine(lease);
            }
        }
        #endregion
        #region GetActiveLeases
        public void GetInActiveLeases()
        {
            List<Lease> allInActiveLeases = _service.GetInActiveLeases();
            foreach (Lease lease in allInActiveLeases)
            {
                Console.WriteLine(lease);
            }
        }
        #endregion
        #region AddPayment
        public void AddPayment()
        {
            Payment payment = new Payment();
            Console.WriteLine("Enter LeaseId::");
            payment.LeaseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Payment Date::");
            payment.PaymentDate = Console.ReadLine();
            Console.WriteLine("Enter Amount::");
            payment.Amount = decimal.Parse(Console.ReadLine());

            try
            {
                int addPaymentStatus = _service.AddPayment(payment);
                if (addPaymentStatus > 0)
                {
                    Console.WriteLine("Payment record added successfully");
                }
            }
            catch (Exception uaex)
            {
                Console.WriteLine(uaex.Message);
            }
        }
        #endregion
        #region GetAllPayments
        public void GetAllPayments()
        {
            List<Payment> allPayments = _service.GetAllPayments();
            foreach (Payment payment in allPayments)
            {
                Console.WriteLine(payment);
            }
        }
        #endregion



    }
}
