using Pizzeria.DTO;
using System;

namespace AutoFixtureExamples.Stubs
{
    class CheeseStub
    {
        public string CheeseName { get; set; }
        public DateTime ValidUntil { get; set; }
        public Cheese ToCheese()
        {
            return new Cheese
            {
                CheeseName = CheeseName,
                ValidUntil = ValidUntil
            };
        }
    }
}
