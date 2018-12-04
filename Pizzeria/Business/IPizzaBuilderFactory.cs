using Pizzeria.DTO;
using System;

namespace Pizzeria.Business
{
    interface IPizzaBuilderFactory
    {
        IPizzaBuilder CreatePizzaBuilder(PizzaName name);
    }

    class PizzaBuilderFactory : IPizzaBuilderFactory
    {
        public IPizzaBuilder CreatePizzaBuilder(PizzaName name)
        {
            switch (name)
            {
                case PizzaName.Hawaiian:
                    return new HawaiianPizzaBuilder();
                case PizzaName.NeapolitanPizza:
                    return new NeapolitanPizzaBuilder();
                case PizzaName.ThreeCheeses:
                    return new ThreeCheesesPizzaBuilder();
                default:
                    throw new ArgumentException($"Pizza '{name}' is not in menu");
            }
        }
    }
}
