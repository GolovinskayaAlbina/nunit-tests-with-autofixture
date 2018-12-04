using Pizzeria.DTO;

namespace Pizzeria.Business
{
    interface IPizzaBuilderDirector
    {
        Pizza Build(IPizzaBuilder builder);
    }

    class PizzaBuilderDirector : IPizzaBuilderDirector
    {
        public Pizza Build(IPizzaBuilder builder)
        {
            builder.AddCheeses();
            builder.AddFilling();
            return builder.GetPizza();
        }
    }
}
