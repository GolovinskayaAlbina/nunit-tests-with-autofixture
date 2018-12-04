using NUnit.Framework;
using Pizzeria.Business;
using Pizzeria.DTO;
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
        public async Task CookPizzaWithCrust()
        {
            var pizza = _fixture.Create<Pizza>();

            var stratery = _fixture.Create<OvenСookingStratery>();

            await stratery.CookAsync(pizza);

            Assert.True(pizza.WithCrust);
        }
    }
}
