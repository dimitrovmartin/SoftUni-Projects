namespace Shapes
{
    public class Rectangle : Shape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public override double CalculateArea()
        {
            return this.height * this.width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * this.height + 2 * this.width;
        }
        public override string Draw()
        {
            return base.Draw() + nameof(Rectangle);
        }
    }
}