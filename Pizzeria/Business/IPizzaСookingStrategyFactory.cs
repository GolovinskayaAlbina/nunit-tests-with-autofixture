namespace Pizzeria.Business
{
    interface IPizzaСookingStrategyFactory
    {
        IPizzaСookingStrategy CreateOvenСookingStratery();
        IPizzaСookingStrategy CreateMicrowaveСookingStratery();
    }

    class PizzaСookingStrategyFactory : IPizzaСookingStrategyFactory
    {
        public IPizzaСookingStrategy CreateMicrowaveСookingStratery()
        {
            return new MicrowaveСookingStratery();
        }

        public IPizzaСookingStrategy CreateOvenСookingStratery()
        {
            return new OvenСookingStratery();
        }
    }
}
