using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();

    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("CreditCalculated Using Before 2010");
        }
    }
    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("CreditCalculated Using After 2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase GetCreditCalculatorBase { get; set; }
        public After2010CreditCalculator CreditCalculatorBase { get; internal set; }

        public void SaveCredit()
        {
            Console.WriteLine("CustomerManager Business");
            CreditCalculatorBase.Calculate();
        }


    }
}
