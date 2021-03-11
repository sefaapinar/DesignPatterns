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
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }
    class Logging:ILogging
    {
        

        public void log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Caching");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacade();
        }



        public void Save()
        {
            _concerns.caching.Cache();
            _concerns.authorize.CheckUser();
            _concerns.logging.log();
            Console.WriteLine("SAVED");
        }
    }

    class CrossCuttongConcernsFacade
    {
        public ILogging logging;
        public ICaching caching;
        public IAuthorize authorize;


        public CrossCuttongConcernsFacade()
        {
            logging = new Logging();
            caching = new Caching();
            authorize = new Authorize();
        }
    }

}
