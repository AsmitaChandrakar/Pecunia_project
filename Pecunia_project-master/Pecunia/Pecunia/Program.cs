using System;
using System.Collections.Generic;
using System.Text;
using Pecunia.Entities;
using Pecunia.BusinessLayer;
using Pecunia.Exceptions;

namespace Pecunia.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:\n ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddCustomer();
                        break;
                    case 2:
                        ListAllCustomers();
                        break;
                    case 3:
                        SearchCustomerByID();
                        break;
                    case 4:
                        UpdateCustomer();
                        break;
                   
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

       

        private static void UpdateCustomer()
        {
            try
            {
                int updateCustomerID;
                Console.WriteLine("Enter Customer ID to Update Details:");
                updateCustomerID = Convert.ToInt32(Console.ReadLine());
                Customer updateCustomer = CustomerBL.SearchCustomerBL(updateCustomerID);
                if (updateCustomer != null)
                {
                    Console.WriteLine("Update Customer Name :");
                    updateCustomer.CustomerName = Console.ReadLine();
                    Console.WriteLine("Update PhoneNumber :");
                    updateCustomer.CustomerContactNumber = Console.ReadLine();
                    bool customerUpdated = CustomerBL.UpdateCustomerBL(updateCustomer);
                    if (customerUpdated)
                        Console.WriteLine("Customer Details Updated");
                    else
                        Console.WriteLine("Customer Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No customer Details Available");
                }


            }
            catch (PecuniaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchCustomerByID()
        {
            try
            {
                int searchCustomer_ID;
                Console.WriteLine("Enter Customer ID to Search:");
                searchCustomer_ID = Convert.ToInt32(Console.ReadLine());
                Customer  searchCustomerID= CustomerBL.SearchCustomerBL(searchCustomer_ID);
                if (searchCustomerID != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Customer ID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchCustomerID.CustomerID, searchCustomerID.CustomerName, searchCustomerID.CustomerContactNumber);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Customer Details Available");
                }

            }
            catch (PecuniaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private static void ListAllCustomers()
        {
            try
            {
                List<Customer> customerList = CustomerBL.GetAllCustomersBL();
                if (customerList != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("Customer ID\t\tName\t\tPhoneNumber");
                    Console.WriteLine("******************************************************************************");
                    foreach (Customer customer in customerList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", customer.CustomerID, customer.CustomerName, customer.CustomerContactNumber);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No account Details Available");
                }
            }
            catch (PecuniaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddCustomer()
        {
            try
            {
                Customer newCustomer = new Customer();

                Console.WriteLine("Enter Customer ID :");
                newCustomer.CustomerID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Customer Name :");
                newCustomer.CustomerName = Console.ReadLine();
                Console.WriteLine("Enter PhoneNumber :");
                newCustomer.CustomerContactNumber = Console.ReadLine();
                bool customerCreated = CustomerBL.CreateCustomerBL(newCustomer);
                if (customerCreated)
                    Console.WriteLine("Customer Added");
                else
                    Console.WriteLine("Customer not Added");
            }
            catch (PecuniaException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Customer Menu***********");
            Console.WriteLine("1. Add customer");
            Console.WriteLine("2. List All customers");
            Console.WriteLine("3. Search customer by ID");
            Console.WriteLine("4. Update customer");
            Console.WriteLine("5. Exit");
           
            Console.WriteLine("******************************************\n");

        }
    }
}
