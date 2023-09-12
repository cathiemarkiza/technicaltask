using System;

namespace RectangleApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Rectangle Application!");

            // Prompt the user for rectangle dimensions
            Console.Write("Enter the length of the rectangle: ");
            double length = GetValidDoubleInput();

            Console.Write("Enter the width of the rectangle: ");
            double width = GetValidDoubleInput();

            // Create a rectangle object
            Rectangle rectangle = new Rectangle(length, width);

            // Calculate and display the area
            double area = rectangle.CalculateArea();
            Console.WriteLine($"Area: {area}");

            // Calculate and display the perimeter
            double perimeter = rectangle.CalculatePerimeter();
            Console.WriteLine($"Perimeter: {perimeter}");

            // Check if the rectangle is a square
            bool isSquare = rectangle.IsSquare();
            Console.WriteLine($"Is Square? {isSquare}");

            // Wait for user input to exit
            Console.ReadLine();
        }

        static double GetValidDoubleInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
            return value;
        }
    }

    class Rectangle
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public double CalculateArea()
        {
            return Length * Width;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Length + Width);
        }

        public bool IsSquare()
        {
            return Length == Width;
        }
    }
}
