using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new Log4NetFactory());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        // We have not depend to any factories. We went from abstract classes
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            //ILogger ıLogger = new LoginLogger(); if we do this we are dependent on LoginLogger
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

    // *********************** factory 1 ***********************
    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new LoginLogger();
        }
    }

    public class LoginLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With LoginLogger!");
        }
    }
    // *********************** factory 1 END ***********************


    // *********************** factory 2 ***********************
    public class Log4NetFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged With Log4NetLogger!");
        }
    }
    // *********************** factory 2 END ***********************


    // interfaces
    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }
}
