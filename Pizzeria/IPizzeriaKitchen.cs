using Pizzeria.DTO;
using System;
using System.Threading.Tasks;

namespace Pizzeria
{
    interface IPizzeriaKitchen
    {
        event Action<Pizza, int> OrderIsReady;
        Task SetOrderAsync(PizzaName pizza, int orderNum);
    }
}
