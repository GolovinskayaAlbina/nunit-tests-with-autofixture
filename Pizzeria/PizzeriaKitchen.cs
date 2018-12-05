using Pizzeria.Business;
using Pizzeria.DTO;
using System;
using System.Threading.Tasks;

namespace Pizzeria
{
    class PizzeriaKitchen : IPizzeriaKitchen
    {
        private readonly IPizzaBuilderDirector _builderDirector;
        private readonly IPizzaBuilderFactory _builderFactory;
        private readonly IPizzaСookingStrategyFactory _сookingStrategyFactory;

        public event Action<Pizza, int> OrderIsReady;
        internal bool IsOvenBroken = false;
        public PizzeriaKitchen(
            IPizzaBuilderDirector builderDirector,
            IPizzaBuilderFactory builderFactory, 
            IPizzaСookingStrategyFactory сookingStrategyFactory)
        {
            _builderDirector = builderDirector;
            _builderFactory = builderFactory;
            _сookingStrategyFactory = сookingStrategyFactory;
        }

        public async Task SetOrderAsync(PizzaName pizzaName, int orderNum)
        {
            var builder = _builderFactory.CreatePizzaBuilder(pizzaName);
            var pizza = _builderDirector.Build(builder);

            var strategy = GetCookingStrategy();
            await strategy.CookAsync(pizza);

            OnOrderIsReady(pizza, orderNum);
        }

        private void OnOrderIsReady(Pizza pizza, int orderNum)
        {
            OrderIsReady?.Invoke(pizza, orderNum);
        }

        private IPizzaСookingStrategy GetCookingStrategy()
        {
            return IsOvenBroken 
                ? _сookingStrategyFactory.CreateMicrowaveСookingStratery()
                : _сookingStrategyFactory.CreateOvenСookingStratery();
        }
    }
}
