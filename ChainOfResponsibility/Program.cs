using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccesor(vicePresident);
            vicePresident.SetSuccesor(president);

            Expense expense = new Expense { Detail ="Traning", Amount = 98};

            manager.HandleExpense(expense);
            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor;
        public abstract void HandleExpense(Expense expense);
        public void SetSuccesor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }


    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount<=100)
            {
                Console.WriteLine("Manager handled the expence");
            }

            else if(Successor!=null)
            {
                Successor.HandleExpense(expense);

            }
        }
    }
    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=100)
            {
                Console.WriteLine("Vice President handled the expence");
            }

            else if (Successor != null)
            {
                Successor.HandleExpense(expense);

            }
        }
    }
    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount >1000)
            {
                Console.WriteLine("President handled the expence");
            }
            
        }
    }
}
