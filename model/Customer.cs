using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.model
{
    public class Customer
    {
        #region getter setter
        private int customerId;
        private string firstName;
        private string lastName;    
        private string email;
        private string phoneNumber;   

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string FirstName
        { 
            get { return firstName; } 
            set { firstName = value; } 
        }   
        public string LastName
        { 
            get { return lastName; } 
            set {  lastName = value; } 
        }
        public string Email
        { 
            get { return email; } 
            set {  email = value; } 
        }
        public string PhoneNumber
        { 
            get { return phoneNumber; } 
            set {  phoneNumber = value; } 
        }
        #endregion
        public Customer()
        {
            
        }
        public Customer(int _customerID , string _firstName, string _lastName, string _email, string _phoneNumber)
        {
            CustomerId = _customerID;
            FirstName = _firstName;
            LastName = _lastName;
            Email = _email;
            PhoneNumber = _phoneNumber;
        }
        public override string ToString()
        {
            return $"CustomerID::{CustomerId} FirstName::{FirstName} LastName:: {LastName} Email::{Email} " +
                $"PhoneNumber:: {PhoneNumber}";
        }

    }
}
