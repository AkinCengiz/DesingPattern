using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customerManeger = CustomerManager.CreateAsSingleton();
            customerManeger.Save();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private static object _lockObject = new object();
        private CustomerManager()
        {

        }

        public static CustomerManager CreateAsSingleton()
        {
            //=======I. YOL ===============
            
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;

            //******************II. YOL**********************
            //return _customerManager ?? (_customerManager = new CustomerManager());
        }

        public void Save()
        {
            Console.WriteLine("Saved!!!");
        }
    }

    class EmployeeManager
    {
        private static EmployeeManager _employeeManager;
        static Object _lockObject = new object();

        private EmployeeManager()
        {
            
        }

        public static EmployeeManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_employeeManager == null)
                {
                    _employeeManager = new EmployeeManager();
                }
            }

            return _employeeManager;
        }
    }

    class ProductManager
    {
        private static ProductManager _productManager;
        private static object _lockObject = new object();

        private ProductManager()
        {

        }

        public static ProductManager CreateAsSingleton()
        {
            lock (_lockObject)
            {
                if (_productManager == null)
                {
                    _productManager = new ProductManager();
                }
            }

            return _productManager;
        }
    }

    class OrderManager
    {
        private static OrderManager _orderManager;
        private static object _lockObject = new object();

        private OrderManager()
        {

        }

        public static OrderManager CreateasSingleton()
        {
            lock (_lockObject)
            {
                if (_orderManager == null)
                {
                    _orderManager = new OrderManager();
                }
            }

            return _orderManager;
        }
    }

}
