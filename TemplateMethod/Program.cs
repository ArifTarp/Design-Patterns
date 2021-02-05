using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            UserAlgorithm algorithm;

            algorithm = new AddCustomerAlgorithm();
            algorithm.AddUser(new { }, "A Server");

            Console.WriteLine("\n ********************** \n");

            algorithm = new AddEmployeeAlgorithm();
            algorithm.AddUser(new { }, "B Server");

            Console.ReadLine();
        }
    }

    class AddEmployeeAlgorithm : UserAlgorithm
    {
        protected override void AddUserToSource(object user, string source)
        {
            Console.WriteLine("Added employee user to " + source);
        }

        protected override void SendMessage(object user)
        {
            Console.WriteLine("Sent message for employee user with E-Mail");
        }
    }

    class AddCustomerAlgorithm : UserAlgorithm
    {
        protected override void AddUserToSource(object user, string source)
        {
            Console.WriteLine("Added customer user to " + source);
        }

        protected override void SendMessage(object user)
        {
            Console.WriteLine("Sent message for customer user with SMS");
        }
    }

    abstract class UserAlgorithm
    {
        // template method
        public void AddUser(object user, string source)
        {
            AddUserToSource(user, source);
            LogUser(user);
            SendMessage(user);
        }

        protected abstract void AddUserToSource(object user, string source);

        private void LogUser(object user)
        {
            Console.WriteLine("Logged user");
        }

        protected abstract void SendMessage(object user);
    }
}
