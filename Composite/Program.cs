using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee arif = new Employee { Name = "Arif Tarpıcı" };
            Employee ishak = new Employee { Name = "İshak Gün" };
            Employee orhan = new Employee { Name = "Orhan Uçar" };
            Employee ali = new Employee { Name = "Ali Derin" };
            Supplier mehmet = new Supplier { Name = "Mehmet"};

            arif.AddSuborinate(ishak);
            arif.AddSuborinate(orhan);
            ishak.AddSuborinate(ali);
            orhan.AddSuborinate(mehmet);

            Console.WriteLine("{0}", arif.Name);
            foreach (Employee manager in arif)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}", employee.Name);
                }
            }

            Console.ReadLine();
        }
    }
    
    class Supplier : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        public string Name { get; set; }

        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSuborinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSuborinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }
}
