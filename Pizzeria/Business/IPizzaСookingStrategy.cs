using Pizzeria.DTO;
using System.Threading.Tasks;

namespace Pizzeria.Business
{
    interface IPizzaСookingStrategy
    {
        Task CookAsync(Pizza pizza);
    }

    class OvenСookingStratery : IPizzaСookingStrategy
    {
        public async Task CookAsync(Pizza pizza)
        {
            await Task.Delay(2000);
            pizza.IsRaw = false;
            pizza.WithCrust = true;
        }
    }

    class MicrowaveСookingStratery : IPizzaСookingStrategy
    {
        public async Task CookAsync(Pizza pizza)
        {
            await Task.Delay(1000);
            pizza.IsRaw = false;
        }
    }
}
