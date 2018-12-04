using Moq;
using NUnit.Framework;
using Pizzeria;
using Pizzeria.Business;
using Pizzeria.DTO;
using Ploeh.AutoFixture;
using System.Threading.Tasks;

namespace AutoFixtureExamples
{
    [TestFixture]
    public class PizzeriaKitchenShould
    {
        [Test]
        public async Task CreatePizzaWithRigthOrderNumberInOven()
        {
            var fixture = new Fixture().Customize(new PizzeriaKitchenCustomization());

            var pizzaName = fixture.Create<PizzaName>();
            var orderNumber = fixture.Create<int>();
            var isOvenBroken = false;

            fixture.Create<Mock<IPizzaСookingStrategyFactory>>()
                .Setup(_ => _.CreateOvenСookingStratery())
                .Returns(new Mock<IPizzaСookingStrategy>().Object);

            var kitchen = fixture.Create<PizzeriaKitchen>();
            kitchen.IsOvenBroken = isOvenBroken;

            kitchen.OrderIsReady += (pizza, orderNum) =>
            {
                Assert.AreEqual(orderNumber, orderNum);
            };

            await kitchen.SetOrderAsync(pizzaName, orderNumber);
        }
        private class PizzeriaKitchenCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.FreezeMoq<IPizzaBuilderDirector>();
                fixture.FreezeMoq<IPizzaBuilderFactory>();
                fixture.FreezeMoq<IPizzaСookingStrategyFactory>();
            }
        }
    }

    static class FixtureExtensions
    { 
        public static Mock<T> FreezeMoq<T>(this IFixture fixture)
            where T : class
        {
            var td = new Mock<T>();
            fixture.Register(() => td);
            fixture.Register(() => td.Object);
            return td;
        }
    }
}
