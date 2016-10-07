namespace DrawingTool
{
    using System;
    using System.Globalization;


    public abstract class Shape
    {
        public abstract void Draw();
     
    }

    public class Square : Shape
    {
        public int side;

        public Square(int side)
        {
            this.side = side;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
            for (int i = 0; i < this.side - 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.side));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.side));
        }
    }

    public class Rectangle : Shape
    {
        public int length;
        public int width;

        public Rectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }
        public override void Draw()
        {
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
            for (int i = 0; i < this.length - 2; i++)
            {
                Console.WriteLine("{0}{1}{0}", '|', new string(' ', this.width));
            }
            Console.WriteLine("{0}{1}{0}", '|', new string('-', this.width));
        }
    }

    public class CorDraw
    {
        public CorDraw(Shape shape)
        {
            this.Draw(shape);
        }

        public void Draw(Shape shape)
        {
            shape.Draw();
        }
    }
    class Program
    {
        static void Main()
        {
            
           
            string typeOfShape = Console.ReadLine();
            Shape shape = null;
            if (typeOfShape == "Square")
            {
                int side = int.Parse(Console.ReadLine());
                Square square = new Square(side);
                shape = square;
            }
            else
            {
                int width = int.Parse(Console.ReadLine());
                int length = int.Parse(Console.ReadLine());
                Rectangle rect = new Rectangle(length, width);
                shape = rect;
            }
            CorDraw drawer = new CorDraw(shape);
        }
    }
}
