namespace RawData
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public double Pressure { get; set; }

        public int Age { get; set; }
    }
}