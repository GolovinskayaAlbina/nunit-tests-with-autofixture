using System;
using System.Threading.Tasks;
using Pizzeria;
using Pizzeria.DTO;

namespace AutoFixtureExamples
{
    class Program
    {
        static void HowToUsePizzaOrder()
        {
            var pizzaOrder = new PizzaOrder();

            Task.WaitAll(
                pizzaOrder.PreparePizzaAsync(PizzaName.Hawaiian, 1),
                pizzaOrder.PreparePizzaAsync(PizzaName.Hawaiian, 2),
                pizzaOrder.PreparePizzaAsync(PizzaName.NeapolitanPizza, 3),
                pizzaOrder.PreparePizzaAsync(PizzaName.ThreeCheeses, 4),
                pizzaOrder.PreparePizzaAsync(PizzaName.Hawaiian, 5),
                pizzaOrder.PreparePizzaAsync(PizzaName.ThreeCheeses, 6),
                pizzaOrder.PreparePizzaAsync(PizzaName.NeapolitanPizza, 7),
                pizzaOrder.PreparePizzaAsync(PizzaName.ThreeCheeses, 8),
                pizzaOrder.PreparePizzaAsync(PizzaName.NeapolitanPizza, 9),
                pizzaOrder.PreparePizzaAsync(PizzaName.Hawaiian, 10),
                pizzaOrder.PreparePizzaAsync(PizzaName.NeapolitanPizza, 11),
                pizzaOrder.PreparePizzaAsync(PizzaName.ThreeCheeses, 12)
            );

            Console.ReadKey();
        }
    }
}
