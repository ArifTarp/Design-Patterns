using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer{Id = 1,FirstName = "Arif",LastName = "Tarpıcı",City = "İstanbul"};

            Customer newCustomer = (Customer)customer.Clone();
            newCustomer.FirstName = "arif";

            /* customer and newCustomer are separate references */
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(newCustomer.FirstName);

            Console.ReadLine();
        }
    }

    public class Customer : Person
    {
        public string City { get; set; }
        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; } 
        public override Person Clone() 
        {
            return (Person)MemberwiseClone();
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
