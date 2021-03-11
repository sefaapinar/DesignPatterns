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

    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public class LogfNetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with logfNet");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);

    }
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
           
        }
    }
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");

        }
    }


    public abstract class CrossCuttingConscernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
       
    }

    public class Factory1 : CrossCuttingConscernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            
            return new LogfNetLogger();
        }
    }

    public class Factory2 : CrossCuttingConscernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();

        }

        public override Logging CreateLogger()
        {
            
            return new LogfNetLogger();
        }
    }

    public class ProductManager
    {
        private CrossCuttingConscernsFactory _crossCuttingConscernsFactory;
        private Logging _loggin;
        private Caching _caching;
        public ProductManager(CrossCuttingConscernsFactory crossCuttingConscernsFactory)
        {
            _crossCuttingConscernsFactory = crossCuttingConscernsFactory;
            _loggin = crossCuttingConscernsFactory.CreateLogger();
            _caching = _crossCuttingConscernsFactory.CreateCaching();
        }
        public void GetAll()
        {
            _loggin.Log("Logged");
            _caching.Cache("Data");
            Console.WriteLine("Products Listed");
        }

    }
}
