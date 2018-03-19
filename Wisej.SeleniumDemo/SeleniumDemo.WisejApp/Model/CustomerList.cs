using System.ComponentModel;
using Wisej.Base;

namespace SeleniumDemo.WisejApp.Model
{
    public class CustomerList : BindingList<Customer>
    {
        private static CustomerList Instance
        {
            get { return ApplicationBase.Session.CustomerList; }
            set { ApplicationBase.Session.CustomerList = value; }
        }

        public static CustomerList GetCustomerList()
        {
            if (Instance == null)
                BuildInstance();

            return Instance;
        }

        public static void ResetData()
        {
            if (Instance == null)
            {
                BuildInstance();
            }
            else
            {
                Instance.Clear();
                Customer.ClearCounter();
                new Customer
                {
                    FirstName = "Enlodado",
                    LastName = "Aguas",
                    State = States.FL
                }.Save();

                new Customer
                {
                    FirstName = "Louis",
                    LastName = "Armstrong",
                    State = States.LA
                }.Save();
            }
        }

        public static bool Contains(int customerId)
        {
            foreach (var customer in Instance)
            {
                if (customer.CustomerId == customerId)
                    return true;
            }

            return false;
        }

        public static Customer GetCustomer(int customerId)
        {
            foreach (var customer in Instance)
            {
                if (customer.CustomerId == customerId)
                    return customer;
            }

            return null;
        }

        private static void BuildInstance()
        {
            Instance = new CustomerList();
            ResetData();
        }
    }
}