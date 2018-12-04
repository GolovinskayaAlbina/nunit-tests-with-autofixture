using NUnit.Framework;
using Pizzeria.Business;
using Pizzeria.DTO;
using System;

namespace AutoFixtureExamples.Business
{
    [TestFixture]
    public class PizzaBuilderFactoryShould
    {
        [TestCase(PizzaName.Hawaiian, typeof(HawaiianPizzaBuilder))]
        [TestCase(PizzaName.NeapolitanPizza, typeof(NeapolitanPizzaBuilder))]
        [TestCase(PizzaName.ThreeCheeses, typeof(ThreeCheesesPizzaBuilder))]
        public void CreatePizzaBuilderForValidPizzasName(PizzaName pizzaName, Type expectedType)
        {
            var factory = new PizzaBuilderFactory();

            var builder = factory.CreatePizzaBuilder(pizzaName);

            Assert.IsInstanceOf(expectedType, builder);
        }

        [Test]
        public void ThrowsArgumentExceptionIfPizzasNameIsInvalid()
        {
            var invalidName = (PizzaName)10;

            var factory = new PizzaBuilderFactory();

            Assert.Throws<ArgumentException>(() => factory.CreatePizzaBuilder(invalidName),
                "Pizza '10' is not in menu");
        }
    }
}
