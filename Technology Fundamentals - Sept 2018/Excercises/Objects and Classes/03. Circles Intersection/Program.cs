using System;
using System.Linq;

namespace _03._Circles_Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputOne = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputTwo = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int x1 = inputOne[0];
            int y1 = inputOne[1];
            int rad1 = inputOne[2];
            Point firstC = new Point(x1, y1);

            int x2 = inputTwo[0];
            int y2 = inputTwo[1];
            int rad2 = inputTwo[2];
            Point secondC = new Point(x2, y2);


            Circle one = new Circle(firstC, rad1);
            Circle two = new Circle(secondC, rad2);
            Console.WriteLine(IntersectCircles(one, two));

        }

        private class Circle
        {
            public Point Point { get; set; }
            public int Radius { get; set; }

            public Circle(Point a, int r)
            {
                this.Point = a;
                this.Radius = r;
            }
        }
        private static string IntersectCircles(Circle a, Circle b)
        {
            string result = "No";
            int x1 = a.Point.posX;
            int y1 = a.Point.posY;
            int x2 = b.Point.posX;
            int y2 = b.Point.posY;
            int side1 = Math.Abs(x1 - x2);
            int side2 = Math.Abs(y1 - y2);

            double dist = Math.Sqrt(side1 * side1 + side2 * side2);
            if (dist <= a.Radius + b.Radius)
            {
                result = "Yes";
            }

            return result;
        }


        class Point
        {

            public int posX { get; set; }
            public int posY { get; set; }

            public Point(int x, int y)
            {
                this.posX = x;
                this.posY = y;
            }
        }
    }
}
