using Pizzeria.DTO;
using System;
using System.Collections.Generic;

namespace Pizzeria.Business
{
    interface IPizzaBuilder
    {
        void AddCheeses();
        void AddFilling();
        Pizza GetPizza();
    }

    class NeapolitanPizzaBuilder : IPizzaBuilder
    {
        private Pizza _pizza;
        public NeapolitanPizzaBuilder()
        {
            var now = DateTime.UtcNow;
            _pizza = new Pizza
            {
                IsRaw = true,
                PizzaName = PizzaName.NeapolitanPizza,
                SettedDate = now,
                ValidUntil = now.AddHours(1),
                Cheeses = new List<Cheese>(),
                Fillings = new List<string>()        
            };
        }

        public void AddCheeses()
        {
            _pizza.Cheeses.Add(new Cheese
            {
                ValidUntil = new DateTime(2018, 12, 31),
                CheeseName = "Mozzarella"
            });
        }

        public void AddFilling()
        {
            _pizza.Fillings.AddRange(new []
            {
                "Shugar",
                "Tomatoes",
                "Olives"
            });
        }

        public Pizza GetPizza()
        {
            return _pizza;
        }
    }

    class ThreeCheesesBuilder : IPizzaBuilder
    {
        private Pizza _pizza;
        public ThreeCheesesBuilder()
        {
            var now = DateTime.UtcNow;
            _pizza = new Pizza
            {
                IsRaw = true,
                PizzaName = PizzaName.ThreeCheeses,
                SettedDate = now,
                ValidUntil = now.AddHours(3),
                Cheeses = new List<Cheese>(),
                Fillings = new List<string>()
            };
        }
        public void AddCheeses()
        {
            _pizza.Cheeses.Add(new Cheese
            {
                ValidUntil = new DateTime(2018, 12, 31),
                CheeseName = "Mozzarella"
            });
            _pizza.Cheeses.Add(new Cheese
            {
                ValidUntil = new DateTime(2019, 1, 31),
                CheeseName = "Parmesan"
            });
            _pizza.Cheeses.Add(new Cheese
            {
                ValidUntil = new DateTime(2018, 12, 20),
                CheeseName = "DorBlu"
            });
        }
        public void AddFilling()
        {
            _pizza.Fillings.AddRange(new[]
            {
                "Shugar",
                "Tomatoes",
            });
        }
        public Pizza GetPizza()
        {
            return _pizza;
        }
    }

    class HawaiianBuilder : IPizzaBuilder
    {
        private Pizza _pizza;
        public HawaiianBuilder()
        {
            var now = DateTime.UtcNow;
            _pizza = new Pizza
            {
                IsRaw = true,
                PizzaName = PizzaName.Hawaiian,
                SettedDate = now,
                ValidUntil = now.AddHours(2),
                Cheeses = new List<Cheese>(),
                Fillings = new List<string>()
            };
        }
        public void AddCheeses()
        {
            _pizza.Cheeses.Add(new Cheese
            {
                ValidUntil = new DateTime(2018, 12, 31),
                CheeseName = "Parmesan"
            });
        }
        public void AddFilling()
        {
            _pizza.Fillings.AddRange(new[]
            {
                "Champignons",
                "Chicken",
                "Pineapple"
            });
        }
        public Pizza GetPizza()
        {
            return _pizza;
        }
    }
}
