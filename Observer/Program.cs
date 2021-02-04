using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager();
            var customerObserver = new CustomerObserver();
            var employeeObserver = new EmployeeObserver();

            productManager.Attach(customerObserver);
            productManager.Attach(employeeObserver);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();

        public void UpdatePrice()
        {
            Console.WriteLine("Product Price Changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.SendMessage();
            }
        }
    }

    class CustomerObserver : Observer
    {
        public override void SendMessage()
        {
            Console.WriteLine("Message To Customer: Product Price Changed!");
        }
    }

    class EmployeeObserver : Observer
    {
        public override void SendMessage()
        {
            Console.WriteLine("Message To Employee: Product Price Changed!");
        }
    }

    abstract class Observer
    {
        public abstract void SendMessage();
    }
}
