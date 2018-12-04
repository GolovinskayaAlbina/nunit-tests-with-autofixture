using Pizzeria.Business;
using Pizzeria.DTO;
using System;
using System.Threading.Tasks;

namespace Pizzeria
{
    public class PizzaOrder
    {
        IPizzeriaKitchen _pizzeriaKitchen;
        public PizzaOrder()
        {
            _pizzeriaKitchen = new PizzeriaKitchen(
                new PizzaBuilderDirector(),
                new PizzaBuilderFactory(),
                new PizzaСookingStrategyFactory());

            _pizzeriaKitchen.OrderIsReady += OrderIsReady;
        }

        private void OrderIsReady(Pizza pizza, int orderNum)
        {
            Console.WriteLine($"{orderNum}: Pizza {pizza.PizzaName} is ready {(pizza.WithCrust ? "with crush": "")}");
        }

        public async Task PreparePizzaAsync(PizzaName pizza, int orderNum)
        {
            await _pizzeriaKitchen.SetOrderAsync(pizza, orderNum);
        }
    }
}
