using Pizzeria.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoFixtureExamples.Stubs
{
    class PizzaStub
    {
        public PizzaName PizzaName { get; set; }
        public List<CheeseStub> Cheeses { get; set; }
        public DateTime SettedDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public List<string> Fillings { get; set; }
        public bool IsRaw { get; set; }
        public bool WithCrust { get; set; }
        public Pizza ToPizza()
        {
            return new Pizza
            {
                PizzaName = PizzaName,
                Fillings = Fillings,
                IsRaw = IsRaw,
                SettedDate = SettedDate,
                ValidUntil = ValidUntil,
                WithCrust = WithCrust,
                Cheeses = Cheeses.Select(_ => _.ToCheese()).ToList()
            };
        }
    }
}
