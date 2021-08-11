using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double DefaultMililiters = 50;
        private const decimal DefaultPrice = 3.5m;

        public Coffee(string name, double caffeine) : base(name, DefaultPrice, DefaultMililiters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
