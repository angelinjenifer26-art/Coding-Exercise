using System;

namespace DesignPatternsDemo.Creational
{
    public interface IShape { void Draw(); }
    public class Circle : IShape { public void Draw() => Console.WriteLine("Drawing Circle"); }
    public class Rectangle : IShape { public void Draw() => Console.WriteLine("Drawing Rectangle"); }

    public class ShapeFactory
    {
        public static IShape GetShape(string type) => type.ToLower() switch
        {
            "circle" => new Circle(),
            "rectangle" => new Rectangle(),
            _ => throw new ArgumentException("Invalid shape type")
        };
    }

    public static class FactoryDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Factory Pattern Demo ---");
            var shape1 = ShapeFactory.GetShape("circle");
            var shape2 = ShapeFactory.GetShape("rectangle");
            shape1.Draw();
            shape2.Draw();
        }
    }
}
