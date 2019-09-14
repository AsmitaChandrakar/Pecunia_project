using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pecunia.DataAccessLayer;
using Pecunia.Exceptions;
using Pecunia.Entities;
using System.Text.RegularExpressions;

namespace Pecunia.BusinessLayer
{
    public class CustomerBL
    {
        private static bool ValidateCustomer(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            bool validCustomer = true;
           
            if (customer.CustomerID!=6)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid Customer ID");

            }
            Regex pattern = new Regex (@"[A-Z][A-Za-z\s]$");
            if ((customer.CustomerName.Length<40)&&((pattern.IsMatch(customer.CustomerName)) == false))
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Name invalid or exceeds 40 characters");

            }
            Regex pattern1 = new Regex(@"^[6-9]{1}[0-9]{9}$");
            if ((customer.CustomerContactNumber.Length <10) && ((pattern1.IsMatch(customer.CustomerContactNumber)) == false))
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Contact Number invalid");

            }
            Regex pattern2 = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if ((pattern2.IsMatch(customer.CustomerEmailID)) == false)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer EmailID invalid");

            }
           
            if (customer.CustomerAddress.Length < 200)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer Address exceeeds 200 characters");

            }
           
            if ((customer.CustomerDOB)>DateTime.Now.AddYears(-18)) 
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Customer DOB invalid OR Customer is below 18 years");

            }
            Regex pattern3 = new Regex(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$");
            if ((customer.CustomerPANno.Length!=10)&&((pattern3.IsMatch(customer.CustomerPANno)) == false))
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid PAN Number");
            }
           
            if (customer.CustomerAadharno!= 12)
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid Aadhar Number");
            }
           
            if ((customer.CustomerGender!='M')|| (customer.CustomerGender != 'm')||(customer.CustomerGender != 'F')||(customer.CustomerGender != 'f'))
            {
                validCustomer = false;
                sb.Append(Environment.NewLine + "Invalid PAN Number");
            }

            if (validCustomer == false)
                throw new PecuniaException(sb.ToString());
            return validCustomer;
        }

        public static bool CreateCustomerBL(Customer newCustomer)
        {
            bool customerCreated = false;
            try
            {
                if (ValidateCustomer(newCustomer))
                {
                    CustomerDAL customerDAL = new CustomerDAL();
                    customerCreated = customerDAL.CreateCustomerDAL(newCustomer);
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return customerCreated;
        }

        public static List<Customer> GetAllcustomersBL()
        {
            List<Customer> customerList = null;
            try
            {
                CustomerDAL customerDAL = new CustomerDAL();
                customerList = customerDAL.GetAllCustomersDAL();
            }
            catch (PecuniaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return customerList;
        }

        public static Customer SearchCustomerBL(string searchCustomerID)
        {
            Customer searchCustomer = null;
            try
            {
                CurrentAccountDAL accountDAL = new CurrentAccountDAL();
                searchAccount = customerDAL.SearchAccountDAL(searchAccountNo);
            }
            catch (PecuniaException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return searchAccount;

        }

        public static bool UpdateAccountBL(CurrentAccount updateAccount)
        {
            bool accountUpdated = false;
            try
            {
                if (ValidateAccount(updateAccount))
                {
                    CurrentAccountDAL accountDAL = new CurrentAccountDAL();
                    accountUpdated = accountDAL.UpdateAccountDAL(updateAccount);
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return accountUpdated;
        }

        public static bool DeleteAccountBL(string deleteAccountNo)
        {
            bool accountDeleted = false;
            try
            {
                Regex rgx = new Regex(@"^[1][0-9]{9}$");

                if (rgx.IsMatch(deleteAccountNo) == true)
                {
                    CurrentAccountDAL accountDAL = new CurrentAccountDAL();
                    accountDeleted = accountDAL.DeleteAccountDAL(deleteAccountNo);
                }
                else
                {
                    throw new PecuniaException("Invalid account no");
                }
            }
            catch (PecuniaException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return accountDeleted;
        }
    }
}
