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
            CreditManager manager = new CreditManager();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadLine();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
        
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 0; i < 10; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }

            return result;
        }
    }

    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();


            }
            return _cachedValue;
        }
    }
}
