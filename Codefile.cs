using System;

namespace Project1.DesignPatterns.AbstractFactory.Creational
{
    public interface ICoffeeAndMore
    {
        ISmall SmallPackage();

        ILarge LargePackage();
    }
    class Coffee : ICoffeeAndMore
    {
        public ISmall SmallPackage()
        {
            return new SmallCoffee();
        }

        public ILarge LargePackage()
        {
            return new LargeCoffee();
        }
    }

    class CoffeeMate : ICoffeeAndMore
    {
        public ISmall SmallPackage()
        {
            return new SmallCoffeeMate();
        }

        public ILarge LargePackage()
        {
            return new LargeCoffeeMate();
        }
    }

    public interface ISmall
    {
        string RegularSmall();
    }

    class SmallCoffee : ISmall
    {
        public string RegularSmall()
        {
            return "Small Coffee(weight:50gm)";
        }
    }

    class SmallCoffeeMate : ISmall
    {
        public string RegularSmall()
        {
            return "Small Coffee Mate(weight: 200gm)";
        }
    }

    public interface ILarge
    {
        string RegularLarge();
        string OfferLarge(ISmall collaborator);
    }

    class LargeCoffee : ILarge
    {
        public string RegularLarge()
        {
            return "Large Coffee(weight: 300gm) ";
        }

        public string OfferLarge(ISmall collaborator)
        {
            var result = collaborator.RegularSmall();

            return $"You get ({result}) with Large Coffee(weight: 300gm)";
        }
    }

    class LargeCoffeeMate : ILarge
    {
        public string RegularLarge()
        {
            return "Large Coffee Mate(weight: 500gm)";
        }

        public string OfferLarge(ISmall collaborator)
        {
            var result = collaborator.RegularSmall();

            return $"you get ({result}) with Large Coffee Mate(weight:500gm)";
        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code for Coffee...");
            ClientMethod(new Coffee());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code for CoffeeMate...");
            ClientMethod(new CoffeeMate());
        }

        public void ClientMethod(ICoffeeAndMore factory)
        {
            var productA = factory.SmallPackage();
            var productB = factory.LargePackage();

            Console.WriteLine(productB.RegularLarge());
            Console.WriteLine(productB.OfferLarge(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}
