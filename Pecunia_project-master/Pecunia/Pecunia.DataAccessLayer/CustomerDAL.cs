using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using Pecunia.Entities;
using Pecunia.Exceptions;

namespace Pecunia.DataAccessLayer
{
    public class CustomerDAL
    {
        public static List<Customer> CustomerList = new List<Customer>();

        public bool CreateCustomerDAL(Customer newCustomer)
        {
            bool customerCreated = false;
            try
            {
                CustomerList.Add(newCustomer);
                customerCreated = true;
            }
            catch (SystemException ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return customerCreated;

        }

        public List<Customer> GetAllCustomersDAL()
        {
            return CustomerList;
        }

        public Customer SearchCustomerDAL(int searchCustomerID)
        {
            Customer searchCustomer = null;
            try
            {
                foreach (Customer item in CustomerList)
                {
                    if (item.CustomerID == searchCustomerID)
                    {
                        searchCustomer = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return searchCustomer;
        }

      


        //Updating or modifying customer details
        public bool UpdateCustomerDAL(Customer updateCustomer)
        {
            bool customerUpdated = false;
            try
            {
                for (int i = 0; i < CustomerList.Count; i++)
                {
                    if (CustomerList[i].CustomerID == updateCustomer.CustomerID)
                    {
                        updateCustomer.CustomerName = CustomerList[i].CustomerName;
                        updateCustomer.CustomerContactNumber = CustomerList[i].CustomerContactNumber;
                        updateCustomer.CustomerEmailID = CustomerList[i].CustomerEmailID;
                        updateCustomer.CustomerAddress = CustomerList[i].CustomerAddress;
                        updateCustomer.CustomerDOB = CustomerList[i].CustomerDOB;
                        updateCustomer.CustomerPANno = CustomerList[i].CustomerPANno;
                        updateCustomer.CustomerAadharno = CustomerList[i].CustomerAadharno;
                        updateCustomer.CustomerGender = CustomerList[i].CustomerGender;

                        customerUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new PecuniaException(ex.Message);
            }
            return customerUpdated;

        }

      

    }
}
