namespace RawData
{
    public class Cargo
    {
        public Cargo(double weight, string type)
        {
            Weight = weight;
            Type = type;
        }

        public double Weight { get; set; }

        public string Type { get; set; }
    }
}