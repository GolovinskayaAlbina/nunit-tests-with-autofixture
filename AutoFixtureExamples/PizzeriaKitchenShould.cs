using Moq;
using NUnit.Framework;
using Pizzeria;
using Pizzeria.Business;
using Pizzeria.DTO;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System.Threading.Tasks;

namespace AutoFixtureExamples
{
    [TestFixture]
    public class PizzeriaKitchenShould
    {
        [Test]
        public async Task CreatePizzaInOvenWithRigthOrderNumberAsync()
        {
            var fixture = new Fixture().Customize(new PizzeriaKitchenCustomization());

            var orderNumber = fixture.Create<int>();

            fixture.Create<Mock<IPizzaСookingStrategyFactory>>()
                .Setup(_ => _.CreateOvenСookingStratery())
                .Returns(fixture.Create<IPizzaСookingStrategy>());

            var kitchen = fixture.Build<PizzeriaKitchen>()
                .With(_ => _.IsOvenBroken, false)
                .Create();

            kitchen.OrderIsReady += (pizza, orderNum) =>
            {
                Assert.AreEqual(orderNumber, orderNum);
            };

            await kitchen.SetOrderAsync(fixture.Create<PizzaName>(), orderNumber);
        }

        [Test]
        public async Task CreatePizzaInOvenWithRigthOrderNumberOptimazedAsync()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var orderNumber = fixture.Create<int>();

            var kitchen = fixture.Build<PizzeriaKitchen>()
                .With(_ => _.IsOvenBroken, false)
                .Create();

            kitchen.OrderIsReady += (pizza, orderNum) =>
            {
                Assert.AreEqual(orderNumber, orderNum);
            };

            await kitchen.SetOrderAsync(fixture.Create<PizzaName>(), orderNumber);
        }

        [Test]
        public async Task CreateMicrowaveCookingStrategyIfOvenIsBrokenAsync()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var factoryMock = fixture.Freeze<Mock<IPizzaСookingStrategyFactory>>();

            var kitchen = fixture.Build<PizzeriaKitchen>()
                .With(_ => _.IsOvenBroken, true)
                .Create();

            await kitchen.SetOrderAsync(fixture.Create<PizzaName>(), fixture.Create<int>());

            factoryMock.Verify(_ => _.CreateMicrowaveСookingStratery(), Times.Once);
        }

        private class PizzeriaKitchenCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.FreezeMoq<IPizzaBuilderDirector>();
                fixture.FreezeMoq<IPizzaBuilderFactory>();
                fixture.FreezeMoq<IPizzaСookingStrategyFactory>();
                fixture.FreezeMoq<IPizzaСookingStrategy>();
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
