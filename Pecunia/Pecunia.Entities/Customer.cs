using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pecunia.Entities
{
    public class Customer
    {
        private int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        private string customerName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        private string customerContactNumber;

        public string CustomerContactNumber
        {
            get { return customerContactNumber; }
            set { customerContactNumber = value; }
        }
        private string customerEmailID;

        public string CustomerEmailID
        {
            get { return customerEmailID; }
            set { customerEmailID = value; }
        }
        private string customerAddress;

        public string CustomerAddress
        {
            get { return customerAddress; }
            set { customerAddress = value; }
        }
        private DateTime customerDOB;

        public DateTime CustomerDOB
        {
            get { return customerDOB; }
            set { customerDOB = value; }
        }
        private string customerPANno;

        public string CustomerPANno
        {
            get { return customerPANno; }
            set { customerPANno = value; }
        }
        private double customerAadharno;

        public double CustomerAadharno
        {
            get { return customerAadharno; }
            set { customerAadharno = value; }
        }
        private char customerGender;

        public char CustomerGender
        {
            get { return customerGender; }
            set { customerGender = value; }
        }


        public Customer()
        {
            customerID = 0;
            customerName = string.Empty;
            customerContactNumber = string.Empty;
            customerEmailID = string.Empty;
            customerAddress = string.Empty;
            customerDOB = DateTime.Now;
            customerPANno = string.Empty;
            customerAadharno = 0;
            //customerGender = "Dont wan";

        }
    }
}
