using Pizzeria.DTO;
using System;
using System.Threading.Tasks;

namespace Pizzeria.Business
{
    interface IPizzaСookingStrategyContainer : IPizzaСookingStrategy
    {
        void SetStrategy(IPizzaСookingStrategy strategy);
    }

    class PizzaСookingStrategyContainer : IPizzaСookingStrategyContainer
    {
        private IPizzaСookingStrategy _strategy;
        public PizzaСookingStrategyContainer(IPizzaСookingStrategy strategy)
        {
            _strategy = strategy;
        }

        public async Task CookAsync(Pizza pizza)
        {
            await _strategy.CookAsync(pizza);
        }

        public void SetStrategy(IPizzaСookingStrategy strategy)
        {
            _strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }
    }
}
