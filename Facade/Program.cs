using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            // normally injected with ioc
            NewCustomerManager customerManager = new NewCustomerManager(
                new CrossCuttingConcernsFacade(new Logging(),new Caching(),new Validation())
                );

            customerManager.Log();
            customerManager.Cache();
            customerManager.CheckUser();

            Console.ReadLine();
        }
    }

    // CustomerManager after use of facade design pattern
    class NewCustomerManager
    {
        private CrossCuttingConcernsFacade _crossCuttingConcernsFacade;

        public NewCustomerManager(CrossCuttingConcernsFacade crossCuttingConcernsFacade)
        {
            _crossCuttingConcernsFacade = crossCuttingConcernsFacade;
        }

        public void Log()
        {
            _crossCuttingConcernsFacade._logging.Log();
        }
        public void Cache()
        {
            _crossCuttingConcernsFacade._caching.Cache();
        }
        public void CheckUser()
        {
            _crossCuttingConcernsFacade._validate.Validate();
        }
    }

    class CrossCuttingConcernsFacade
    {
        public ILogging _logging;
        public ICaching _caching;
        public IValidate _validate;

        public CrossCuttingConcernsFacade(ILogging logging, ICaching caching, IValidate validate)
        {
            _logging = logging;
            _caching = caching;
            _validate = validate;
        }
    }

    // CustomerManager before use of facade design pattern
    class OldCustomerManager
    {
        private ILogging _logging;
        private ICaching _caching;
        private IValidate _validate;

        public OldCustomerManager(ILogging logging, ICaching caching, IValidate validate)
        {
            _logging = logging;
            _caching = caching;
            _validate = validate;
        }

        public void Log()
        {
            _logging.Log();
        }
        public void Cache()
        {
            _caching.Cache();
        }
        public void CheckUser()
        {
            _validate.Validate();
        }
    }

    // classes
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }

    // interfaces
    interface ILogging
    {
        void Log();
    }

    interface ICaching
    {
        void Cache();
    }

    interface IValidate
    {
        void Validate();
    }
}
