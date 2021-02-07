using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager ali = new Manager{Name = "Ali", Salary = 1000};
            Manager orhan = new Manager { Name = "Orhan", Salary = 900};
            Worker ishak = new Worker{Name = "İshak", Salary = 800};
            Worker arif = new Worker { Name = "Arif", Salary = 800 };

            ali.Subordinates.Add(orhan);
            orhan.Subordinates.Add(ishak);
            orhan.Subordinates.Add(arif);

            OrganisationalStructure organisationalStructure = new OrganisationalStructure(ali);

            PaymentVisitor paymentVisitor = new PaymentVisitor();
            SalaryRiseVisitor salaryRiseVisitor = new SalaryRiseVisitor();

            organisationalStructure.Accept(paymentVisitor);
            organisationalStructure.Accept(salaryRiseVisitor);

            Console.ReadLine();
        }
    }

    class OrganisationalStructure
    {
        public EmployeeBase _employeeBase;

        public OrganisationalStructure(EmployeeBase employeeBase)
        {
            _employeeBase = employeeBase;
        }

        public void Accept(VisitorBase visitor)
        {
            _employeeBase.Accept(visitor);
        }
    }

    class Manager : EmployeeBase
    {
        public List<EmployeeBase> Subordinates { get; set; }

        public Manager()
        {
            Subordinates = new List<EmployeeBase>();
        }

        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);

            foreach (var employee in Subordinates)
            {
                employee.Accept(visitor);
            }
        }
    }

    class Worker : EmployeeBase
    {
        public override void Accept(VisitorBase visitor)
        {
            visitor.Visit(this);
        }
    }

    class PaymentVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} paid {1}",worker.Name,worker.Salary);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} paid {1}", manager.Name, manager.Salary);
        }
    }

    
    class SalaryRiseVisitor : VisitorBase
    {
        public override void Visit(Worker worker)
        {
            Console.WriteLine("{0} salary increased to {1}", worker.Name, worker.Salary * (decimal)1.1);
        }

        public override void Visit(Manager manager)
        {
            Console.WriteLine("{0} salary increased to {1}", manager.Name, manager.Salary* (decimal)1.2);
        }
    }

    abstract class EmployeeBase
    {
        public abstract void Accept(VisitorBase visitor);
        public string Name { get; set; }
        public decimal Salary { get; set; }
    }

    abstract class VisitorBase
    {
        public abstract void Visit(Worker worker);
        public abstract void Visit(Manager manager);
    }
}
