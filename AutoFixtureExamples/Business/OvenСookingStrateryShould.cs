using AutoFixtureExamples.Stubs;
using NUnit.Framework;
using Pizzeria.Business;
using Ploeh.AutoFixture;
using System.Threading.Tasks;

namespace AutoFixtureExamples.Business
{
    [TestFixture]
    public class OvenСookingStrateryShould
    {
        private IFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new Fixture();
        }

        [Test]
        public async Task CookPizzaWithCrustAsync()
        {
            var pizza = _fixture.Create<PizzaStub>().ToPizza();

            var stratery = _fixture.Create<OvenСookingStratery>();

            await stratery.CookAsync(pizza);

            Assert.True(pizza.WithCrust);
        }
    }
}
