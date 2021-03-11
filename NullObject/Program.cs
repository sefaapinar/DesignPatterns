using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class CustomerManager
    {
        private Ilogger _logger;
        public CustomerManager (Ilogger logger)
        {
            _logger = logger;
        }
        public void Save()
        {
            Console.WriteLine("Saved");
            _logger.log();
        }
    }
    interface Ilogger
    {
        void log();
    }
    class Log4NetLogger : Ilogger
    {
        public void log()
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }
    class NlogLogger : Ilogger
    {
        public void log()
        {
            Console.WriteLine("Logged with Nlogger");
        }
    }
    class StubLogger : Ilogger
    {
        private static StubLogger _stubLogger;
        private static object _lock = new object();

        private StubLogger()
        {

        }
        public static StubLogger GetLogger()
        {
            lock (_lock)
            {
                if (_stubLogger ==null)
                {
                    _stubLogger = new StubLogger();

                }
              

            }
            return _stubLogger;

        }
        public void log()
        {
            
        }
    }

    class CustomerManagerTests
    {
        public void SaveTest()
        {
            CustomerManager customerManager = new CustomerManager(StubLogger.GetLogger());
            customerManager.Save();
        }
    }
}
