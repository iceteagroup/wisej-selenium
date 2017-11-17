using System.ComponentModel;

namespace SeleniumDemo.WisejApp.Model
{
    public class CustomerList : BindingList<Customer>
    {
        private static CustomerList _instance;

        public static CustomerList GetCustomerList()
        {
            if (_instance == null)
                BuildInstance();

            return _instance;
        }

        public static void ResetData()
        {
            if (_instance == null)
            {
                BuildInstance();
            }
            else
            {
                _instance.Clear();
                Customer.ClearCounter();
                new Customer
                {
                    FirstName = "Muddy",
                    LastName = "Waters",
                    State = States.MS
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
            foreach (var customer in _instance)
            {
                if (customer.CustomerId == customerId)
                    return true;
            }

            return false;
        }

        public static Customer GetCustomer(int customerId)
        {
            foreach (var customer in _instance)
            {
                if (customer.CustomerId == customerId)
                    return customer;
            }

            return null;
        }

        private static void BuildInstance()
        {
            _instance = new CustomerList();
            ResetData();
        }
    }
}