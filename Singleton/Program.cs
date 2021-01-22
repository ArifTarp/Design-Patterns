using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Message();

            Console.ReadKey();
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;
        private static object _lockObject = new object();

        // barrier to outside access with private constructor
        private CustomerManager()
        {
            
        }

        // If the instance of CustomerManager already exists we will give the existing one
        // otherwise we will create a new one and give
        public static CustomerManager CreateAsSingleton()
        {
            // multithread protection with lock
            lock (_lockObject)
            {
                if (_customerManager == null)
                {
                    _customerManager = new CustomerManager();
                }
            }
            return _customerManager;
        }

        public void Message()
        {
            Console.WriteLine("Created CustomerManager instance or gave the existing one");
        }
    }
}
