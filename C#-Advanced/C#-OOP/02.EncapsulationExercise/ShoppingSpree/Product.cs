namespace ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;

            private set
            {
                Validator.IsNullOrWhiteSpace(value);

                name = value;
            }
        }

        public decimal Cost
        {
            get => cost;

            private set
            {
                Validator.IsNegativeNumber(value);

                cost = value;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}