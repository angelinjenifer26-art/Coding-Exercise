using System;
using System.Collections.Generic;

namespace DesignPatternsDemo.Behavioral
{
    public interface IWeatherObserver { void Update(string weather); }

    public class WeatherStation
    {
        private List<IWeatherObserver> observers = new();
        public void Attach(IWeatherObserver obs) => observers.Add(obs);
        public void Notify(string weather)
        {
            foreach (var obs in observers) obs.Update(weather);
        }
    }

    public class WeatherApp : IWeatherObserver
    {
        private string name;
        public WeatherApp(string n) => name = n;
        public void Update(string weather) => Console.WriteLine($"{name} received update: Weather is {weather}");
    }

    public static class ObserverDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Observer Pattern Demo ---");
            var station = new WeatherStation();
            station.Attach(new WeatherApp("MobileApp"));
            station.Attach(new WeatherApp("DesktopApp"));
            station.Notify("Sunny");
            station.Notify("Rainy");
        }
    }
}
