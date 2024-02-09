using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.model
{
    public class Payment
    {
        #region getter setter
        private int paymentId;
        private int leaseId;
        private string paymentDate;
        private decimal amount;

        public int PaymentId
        {
            get { return paymentId; }
            set { paymentId = value; }
        }
        public int LeaseId
        { 
            get { return leaseId; } 
            set {  leaseId = value; } 
        }
        public string PaymentDate
        { 
            get { return paymentDate; } 
            set {  paymentDate = value; } 
        }
        public decimal Amount
        { 
            get { return amount; } 
            set {  amount = value; } 
        }
        #endregion
        public Payment()
        {
            
        }
        public Payment(int _paymentId, int _leaseId, string _paymentDate,decimal _amount)
        {
            PaymentId = _paymentId;
            LeaseId = _leaseId;
            PaymentDate = _paymentDate;
            Amount = _amount;
            
        }
        public override string ToString()
        {
            return $"PaymentId::{PaymentId} LeaseId::{LeaseId} PaymentDate:: {PaymentId} Amount::{Amount} ";
        }

    }
}
