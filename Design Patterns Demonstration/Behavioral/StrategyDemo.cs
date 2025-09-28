using System;

namespace DesignPatternsDemo.Behavioral
{
    public interface IPaymentStrategy { void Pay(double amount); }
    public class CreditCardPayment : IPaymentStrategy { public void Pay(double amt) => Console.WriteLine($"Paid {amt} using Credit Card."); }
    public class UpiPayment : IPaymentStrategy { public void Pay(double amt) => Console.WriteLine($"Paid {amt} using UPI."); }

    public class PaymentContext
    {
        private IPaymentStrategy strategy;
        public PaymentContext(IPaymentStrategy s) => strategy = s;
        public void PayBill(double amt) => strategy.Pay(amt);
    }

    public static class StrategyDemo
    {
        public static void Run()
        {
            Console.WriteLine("\n--- Strategy Pattern Demo ---");
            new PaymentContext(new CreditCardPayment()).PayBill(200);
            new PaymentContext(new UpiPayment()).PayBill(50);
        }
    }
}
