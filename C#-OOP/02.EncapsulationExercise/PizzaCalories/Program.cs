using System;
using System.Linq;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
                string name = Console.ReadLine()
                .Split(" ")[1];

                string[] doughData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string flourType = doughData[1];
                string backingTechnique = doughData[2];
                int doughWeight = int.Parse(doughData[3]);

            try
            {
                Dough dough = new Dough(flourType, backingTechnique, doughWeight);
                Pizza pizza = new Pizza(name, dough);

                string line = Console.ReadLine();

                while (line != "END")
                {
                    string[] toppingData = line
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string toppingType = toppingData[1];
                    int toppingWeight = int.Parse(toppingData[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    line = Console.ReadLine();
                }

                Console.WriteLine(pizza);
            }

            catch (Exception ex)
            when (ex is ArgumentException || ex is InvalidOperationException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
