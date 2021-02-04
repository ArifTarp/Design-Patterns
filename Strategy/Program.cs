using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CustomerDbOperations = new ADataBase();
            customerManager.SaveCustomer();

            customerManager.CustomerDbOperations = new BDataBase();
            customerManager.SaveCustomer();

            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public CustomerDbOperations CustomerDbOperations { get; set; }
        public void SaveCustomer()
        {
            CustomerDbOperations.Add();
            Console.WriteLine("Customer Added");
        }
    }

    class ADataBase : CustomerDbOperations
    {
        public override void Add()
        {
            Console.WriteLine("Customer add to A database");
        }
    }

    class BDataBase : CustomerDbOperations
    {
        public override void Add()
        {
            Console.WriteLine("Customer add to B database");
        }
    }

    abstract class CustomerDbOperations
    {
        public abstract void Add();
    }
}
