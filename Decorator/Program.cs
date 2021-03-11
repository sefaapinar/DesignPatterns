using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar { Make = "BMW", Model = "3.2O", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            Console.WriteLine("Concrete : {0}", personelCar.HirePrice);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);
            Console.ReadLine();
        }
    }
    abstract class CarBase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonelCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _careBase;
        protected CarDecoratorBase(CarBase carBase)
        {
            _careBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public SpecialOffer(CarBase carBase): base(carBase)
        {

        }
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }
}
