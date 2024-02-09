using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Service
{
    internal interface ICarLeaseService
    {
        void RemoveVehicle();
        void RegisterVehicle();
        void GetAllVehicles();
        void GetAllRentedVehicles();
        void FindVehicleById();
        void AddCustomer();
        void RemoveCustomer();
        void GetAllCustomers();
        void FindCustomersById();
        void AddLease();
        void FindLeaseById();
        void GetActiveLeases();
        void GetInActiveLeases();
        void AddPayment();
        void GetAllPayments();

    }
}

