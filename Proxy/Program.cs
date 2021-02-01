using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBase employeeManagerProxy = new EmployeeManagerProxy();
            Console.WriteLine(employeeManagerProxy.StaffNumber());
            Console.WriteLine(employeeManagerProxy.StaffNumber());

            Console.ReadLine();
        }
    }

    class EmployeeManagerProxy : EmployeeBase
    {
        private EmployeeManager _employeeManager;
        private int _cachedValue;

        public override int StaffNumber()
        {
            if (_employeeManager == null)
            {
                Console.WriteLine("Called first time");
                _employeeManager = new EmployeeManager();
                _cachedValue = _employeeManager.StaffNumber();
            }
            Console.WriteLine("Called more than one");
            return _cachedValue;
        }
    }

    class EmployeeManager : EmployeeBase
    {
        public override int StaffNumber()
        {
            // Let's assume bring data from database

            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    abstract class EmployeeBase
    {
        public abstract int StaffNumber();
    }
}
