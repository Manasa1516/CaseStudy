using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using CarRentalSystem.Exceptions;
using CarRentalSystem.model;
using CarRentalSystem.Utility;

namespace CarRentalSystem.Repository
{
    public class CarLeaseRepository : ICarLeaseRepository
    {
        public string connectionString;
        SqlCommand cmd = null;
        
        public CarLeaseRepository()
        {
            connectionString = DBConnectionUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        //VEHICLE MANAGEMENT
        #region GetAllVehicles
        public List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicleList = new List<Vehicle>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Vehicle Where Status = 'Available'";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.VehicleId = (int)reader["VehicleId"];
                        vehicle.Make = (String)reader["Make"];
                        vehicle.Model = (String)reader["Model"];
                        vehicle.Year = (int)reader["Year"];
                        vehicle.Status = (string)reader["Status"];
                        vehicle.DailyRate = (decimal)reader["DailyRate"];
                        vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                        vehicle.EngineCapacity = (int)reader["EngineCapacity"];

                        vehicleList.Add(vehicle);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicleList;
        }
        #endregion
        #region RegisterVehicle
        public int RegisterVehicle(Vehicle vehicle)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Vehicle values(@Make,@Model,@Year,@DailyRate,@Status,@PassengerCapacity,@EngineCapacity)";
                cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                cmd.Parameters.AddWithValue("@DailyRate", vehicle.DailyRate);
                cmd.Parameters.AddWithValue("@Status", vehicle.Status);
                cmd.Parameters.AddWithValue("@PassengerCapacity", vehicle.PassengerCapacity);
                cmd.Parameters.AddWithValue("@EngineCapacity", vehicle.EngineCapacity);

                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addVehicleStatus = cmd.ExecuteNonQuery();
                return addVehicleStatus;
            }
        }
        #endregion
        #region GetAllRentedVehicles
        public List<Vehicle> GetAllRentedVehicles()
        {
            List<Vehicle> RentedvehicleList = new List<Vehicle>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "SELECT * FROM Vehicle WHERE status = 'notAvailable'";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle();
                        vehicle.VehicleId = (int)reader["VehicleId"];
                        vehicle.Make = (String)reader["Make"];
                        vehicle.Model = (String)reader["Model"];
                        vehicle.Year = (int)reader["Year"];
                        vehicle.Status = (string)reader["Status"];
                        vehicle.DailyRate = (decimal)reader["DailyRate"];
                        vehicle.PassengerCapacity = (int)reader["PassengerCapacity"];
                        vehicle.EngineCapacity = (int)reader["EngineCapacity"];

                        RentedvehicleList.Add(vehicle);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return RentedvehicleList;
        }
        #endregion
        #region RemoveVehicle
        public int RemoveVehicle(Vehicle vehicle)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "DELETE FROM Vehicle WHERE vehicleID = @VehicleId";
                cmd.Parameters.AddWithValue("@VehicleId", vehicle.VehicleId);
                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addRemoveVehicleStatus = cmd.ExecuteNonQuery();
                return addRemoveVehicleStatus;
            }
        }
        #endregion
        #region FindVehicleById
        public List<Vehicle> FindVehicleById(int vehicleId)
        {
            List<Vehicle> findVehicleByIdList = new List<Vehicle>();

                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Vehicle WHERE vehicleId = @VehicleId";
                        cmd.Parameters.AddWithValue("@VehicleId", vehicleId);
                        cmd.Connection = sqlconn;
                        sqlconn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Vehicle vehicle = new Vehicle
                                {
                                    VehicleId = (int)reader["VehicleId"],
                                    Make = (string)reader["Make"],
                                    Model = (string)reader["Model"],
                                    Year = (int)reader["Year"],
                                    Status = (string)reader["Status"],
                                    DailyRate = (decimal)reader["DailyRate"],
                                    PassengerCapacity = (int)reader["PassengerCapacity"],
                                    EngineCapacity = (int)reader["EngineCapacity"]
                                };

                                findVehicleByIdList.Add(vehicle);
                            }
                            else
                            {
                                throw new CarNotFoundException($"No vehicle found with VehicleId: {vehicleId}");
                            }
                        }
                    }
                }

            return findVehicleByIdList;
        }
        #endregion
        //CUSTOMER MANAGEMENT
        #region AddCustomer
        public int AddCustomer(Customer customer)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Customer values(@FirstName,@LastName,@Email,@PhoneNumber)";
                cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addCustomerStatus = cmd.ExecuteNonQuery();
                return addCustomerStatus;
            }
        }
        #endregion
        #region RemoveCustomer
        public int RemoveCustomer(Customer customer)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "DELETE FROM Customer WHERE customerID = @CustomerId";
                cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addRemoveCustomerStatus = cmd.ExecuteNonQuery();
                return addRemoveCustomerStatus;
            }
        }
        #endregion
        #region ListAllCustomers
        public List<Customer> GetAllCustomers()
        {
            List<Customer> customerList = new List<Customer>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Customer";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerId = (int)reader["CustomerId"];
                        customer.FirstName = (String)reader["FirstName"];
                        customer.LastName = (String)reader["LastName"];
                        customer.Email = (String)reader["Email"];
                        customer.PhoneNumber = (String)reader["PhoneNumber"];
                        customerList.Add(customer);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return customerList;
        }
        #endregion
        #region FindCustomerById
        public List<Customer> FindCustomerById(int customerId)
        {
            List<Customer> findCustomerByIdList = new List<Customer>();

                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Customer WHERE customerId = @CustomerId";
                        cmd.Parameters.AddWithValue("@CustomerId", customerId);
                        cmd.Connection = sqlconn;
                        sqlconn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Customer customer = new Customer
                                {
                                    CustomerId = (int)reader["CustomerId"],
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    Email = (string)reader["Email"],
                                    PhoneNumber = (string)reader["PhoneNumber"],
                                };

                                findCustomerByIdList.Add(customer);
                            }
                            else
                            {
                                throw new CustomerrNotFoundException($"No customer found with customerId: {customerId}");
                            }
                        }
                    }
                }

            return findCustomerByIdList;
        }
        #endregion
        //LEASE MANAGEMENT
        #region AddLease
        public int AddLease(Lease lease)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Lease values(@VehicleId,@CustomerId,@StartDate,@EndDate,@TypeL)";
                cmd.Parameters.AddWithValue("@VehicleId", lease.VehicleId);
                cmd.Parameters.AddWithValue("@CustomerId", lease.CustomerId);
                cmd.Parameters.AddWithValue("@StartDate", lease.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", lease.EndDate);
                cmd.Parameters.AddWithValue("@TypeL", lease.TypeL);
                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addLeaseStatus = cmd.ExecuteNonQuery();
                return addLeaseStatus;
            }
        }
        #endregion
        #region FindLeaseById
        public List<Lease> FindLeaseById(int leaseId)
        {
            List<Lease> findLeaseByIdList = new List<Lease>();

                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "SELECT * FROM Lease WHERE leaseId = @LeaseId";
                        cmd.Parameters.AddWithValue("@LeaseId", leaseId);
                        cmd.Connection = sqlconn;
                        sqlconn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Lease lease = new Lease
                                {
                                    LeaseId = (int)reader["LeaseId"],
                                    VehicleId = (int)reader["VehicleId"],
                                    CustomerId = (int)reader["CustomerId"],
                                    StartDate = (string)reader["StartDate"],
                                    EndDate = (string)reader["EndDate"],
                                    TypeL = (string)reader["TypeL"],
                                };

                                findLeaseByIdList.Add(lease);
                            }
                            else
                            {
                                throw new LeaseNotFoundException($"No Lease found with LeaseId: {leaseId}");
                            }
                        }
                    }
                }

            return findLeaseByIdList;
        }
        #endregion
        #region GetActiveLeases
        public List<Lease> GetActiveLeases()
        {
            List<Lease> ActiveLeaseList = new List<Lease>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Select * From Lease Where (endDate > getDate())";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Lease lease = new Lease();
                        lease.LeaseId = (int)reader["LeaseId"];
                        lease.VehicleId = (int)reader["VehicleId"];
                        lease.CustomerId = (int)reader["CustomerId"];
                        lease.StartDate = (String)reader["StartDate"];
                        lease.EndDate = (String)reader["EndDate"];
                        lease.TypeL = (String)reader["TypeL"];
                        ActiveLeaseList.Add(lease);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ActiveLeaseList;
        }
        #endregion
        #region GetInActiveLeases
        public List<Lease> GetInActiveLeases()
        {
            List<Lease> ActiveLeaseList = new List<Lease>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "Select * From Lease";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Lease lease = new Lease();
                        lease.LeaseId = (int)reader["LeaseId"];
                        lease.VehicleId = (int)reader["VehicleId"];
                        lease.CustomerId = (int)reader["CustomerId"];
                        lease.StartDate = (String)reader["StartDate"];
                        lease.EndDate = (String)reader["EndDate"];
                        lease.TypeL = (String)reader["TypeL"];

                        ActiveLeaseList.Add(lease);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ActiveLeaseList;
        }
        #endregion
        //PAYMENT HANDLING
        #region AddPayment
        public int AddPayment(Payment payment)
        {
            using (SqlConnection sqlconn = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Payment values(@LeaseId,@PaymentDate,@Amount)";
                cmd.Parameters.AddWithValue("@LeaseId", payment.LeaseId);
                cmd.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@Amount", payment.Amount);
                cmd.Connection = sqlconn;
                sqlconn.Open();
                int addLeaseStatus = cmd.ExecuteNonQuery();
                return addLeaseStatus;
            }
        }
        #endregion
        #region ListAllPayments
        public List<Payment> GetAllPayments()
        {
            List<Payment> paymentList = new List<Payment>();
            try
            {
                using (SqlConnection sqlconn = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Payment";
                    cmd.Connection = sqlconn;
                    sqlconn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Payment payment = new Payment();
                        payment.PaymentId = (int)reader["PaymentId"];
                        payment.LeaseId = (int)reader["LeaseId"];
                        payment.PaymentDate = (String)reader["PaymentDate"];
                        payment.Amount = (decimal)reader["Amount"];
                        paymentList.Add(payment);

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return paymentList;
        }
        #endregion


    }
}
