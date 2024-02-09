using CarRentalSystem.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Repository
{
    public interface ICarLeaseRepository
    {
        int RemoveVehicle(Vehicle vehicle);
        List<Vehicle> GetAllVehicles();
        List<Vehicle> GetAllRentedVehicles();
        int RegisterVehicle(Vehicle vehicle);
        List<Vehicle> FindVehicleById(int vehicleId);
        int AddCustomer(Customer customer);
        int RemoveCustomer(Customer customer);
        List<Customer> GetAllCustomers();
        List<Customer> FindCustomerById(int customerId);
        int AddLease(Lease lease);
        List<Lease> FindLeaseById(int leaseId);
        List<Lease> GetActiveLeases();
        List<Lease> GetInActiveLeases();
        int AddPayment(Payment payment);
        List<Payment> GetAllPayments();




    }
}
