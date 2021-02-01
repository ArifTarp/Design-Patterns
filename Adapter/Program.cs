using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();

            Console.ReadLine();
        }
    }

    // ************** our system *****************

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("Given data");
            Console.Write("Saved");
        }
    }

    class Logger : ILogger // logger of our system
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged with our system, data: {0}", message);
        }
    }

    internal interface ILogger
    {
        void Log(string message);
    }

    // ************** our system END *****************


    // our adapter
    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }

    // Let's assume we added new system to our system
    // We should not change new system codes that added
    class Log4Net
    {
        // default new system codes
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged With Log4Net, data: {0}", message);
        }
    }
}
