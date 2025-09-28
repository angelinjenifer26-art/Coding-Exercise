using System;

namespace DesignPatternsDemo.Structural
{
    public interface ICoffee { string GetDescription(); double Cost(); }
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double Cost() => 5.0;
    }

    public class CoffeeDecorator : ICoffee
    {
        protected ICoffee coffee;
        public CoffeeDecorator(ICoffee c) => coffee = c;
        public virtual string GetDescription() => coffee.GetDescription();
        public virtual double Cost() => coffee.Cost();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee c) : base(c) { }
        public override string GetDescription() => coffee.GetDescription() + ", Milk";
        public override double Cost() => coffee.Cost() + 2.0;
    }

    public static class DecoratorDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Decorator Pattern Demo ---");
            ICoffee coffee = new SimpleCoffee();
            Console.WriteLine($"{coffee.GetDescription()} costs {coffee.Cost()}");

            ICoffee milkCoffee = new MilkDecorator(coffee);
            Console.WriteLine($"{milkCoffee.GetDescription()} costs {milkCoffee.Cost()}");
        }
    }
}
