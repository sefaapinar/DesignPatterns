using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            ModifedState modifed = new ModifedState();
            modifed.doAction(context);

            DeletedState deleted = new DeletedState();
            deleted.doAction(context);

            Console.WriteLine(context.GetState().ToString());

            Console.ReadLine();
            
            
        }
    }

    interface IState
    {
        void doAction(Context context);
    }

    class ModifedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Modified");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Modified";
        }
    }
    class DeletedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Deleted");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Deleted";
        }
    }
    class AddedState : IState
    {
        public void doAction(Context context)
        {
            Console.WriteLine("State : Added");
            context.SetState(this);
        }
        public override string ToString()
        {
            return "Added";
        }
    }
    class Context
    {
        private IState _state;
        public void SetState(IState state)
        {
            _state = state;
        }

        public IState GetState()
        {
            return _state;
        }
    }
}
