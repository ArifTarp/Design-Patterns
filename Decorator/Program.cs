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
            var personalCar = new PersonalCar{Brand = "TOGG", Model = "SUV",HirePrice = 2500};

            SpecialOfferDecorator specialOfferDecorator = new SpecialOfferDecorator(personalCar);
            specialOfferDecorator._discountPercentage = 10;

            Console.WriteLine("Not Special Offer : {0}", personalCar.HirePrice);
            Console.WriteLine("Special Offer : {0}", specialOfferDecorator.HirePrice);

            Console.ReadLine();
        }
    }

    class SpecialOfferDecorator : CarDecoratorBase
    {
        private CarBase _carBase;
        public int _discountPercentage;

        public SpecialOfferDecorator(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice
        {
            get { return _carBase.HirePrice - _carBase.HirePrice * _discountPercentage / 100; }
            set { }
        }
    }

    abstract class CarDecoratorBase : CarBase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class PersonalCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Brand { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarBase
    {
        public abstract string Brand { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }
}
