# nunit-tests-with-autofixture

* [AutoFixture Github](https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet)

* [AutoFixture Ploeh blog](http://blog.ploeh.dk/page33/)

* [AutoMoqCustomization Ploeh blog](http://blog.ploeh.dk/2010/08/19/AutoFixtureasanauto-mockingcontainer/)

* [Write 30% Less Test Code With AutoFixture](https://www.barbarianmeetscoding.com/blog/2014/07/02/write-30-percent-less-test-code-with-autofixture/)

* [Generating Mock Data using Autofixture](http://www.dotnetfunda.com/articles/show/3424/generating-mock-data-using-autofixture)

* [Examples of using behaviors](https://github.com/AutoFixture/AutoFixture/wiki/Examples-of-using-behaviors)

* [NExpect](https://github.com/fluffynuts/NExpect)

## Examples

```cs
        [Test]
        public async Task CookPizzaWithCrustAsync()
        {
            var pizza = _fixture.Create<Pizza>();

            var stratery = _fixture.Create<OvenСookingStratery>();

            await stratery.CookAsync(pizza);

            Assert.True(pizza.WithCrust);
        }
```

```cs
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
```