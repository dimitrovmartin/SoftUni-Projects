using System;

namespace JedaiEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int countStudents = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalLightsaberPrice = lightsaberPrice * countStudents + (lightsaberPrice * Math.Ceiling(countStudents * 0.1));
            double totalRobePrice = robePrice * countStudents;

            double freebelts = countStudents / 6;

            double totalBeltPrice = beltPrice * (countStudents - freebelts);

            double totalMoney = totalLightsaberPrice + totalRobePrice + totalBeltPrice;

            if (money >= totalMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoney:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {totalMoney - money:f2}lv more.");
            }
        }
    }
}
