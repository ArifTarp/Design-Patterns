using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Factory1());
            productManager.GetAll();

            Console.ReadLine();
        }
    }

    // this is client, in other words business
    public class ProductManager
    {
        private CrossCuttingConcernFactory _crossCuttingConcernFactory;
        private Logging _logging;
        private Caching _caching;

        public ProductManager(CrossCuttingConcernFactory crossCuttingConcernFactory)
        {
            _crossCuttingConcernFactory = crossCuttingConcernFactory;
            _logging = _crossCuttingConcernFactory.CreateLogger();
            _caching = _crossCuttingConcernFactory.CreateCaching();
        }

        public void GetAll()
        {
            _logging.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products Listed!");
        }
    }

    // *********************** factory 1 ***********************
    public class Factory1 : CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    // *********************** factory 1 END ***********************

    // *********************** factory 2 ***********************
    public class Factory2 : CrossCuttingConcernFactory
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    // *********************** factory 2 END ***********************

    public class Log4NetLogger : Logging
    {
        public override void Log(string data)
        {
            Console.WriteLine("Logged With Log4NetLogger and data: " + data);
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string data)
        {
            Console.WriteLine("Logged With NLogger and data: " + data);
        }
    }

    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached With MemCache and data: " + data);
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached With RedisCache and data: " + data);
        }
    }

    // abstracts
    public abstract class CrossCuttingConcernFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }
}
