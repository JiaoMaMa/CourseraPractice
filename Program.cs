using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Assignment1 code
    /// </summary>
    class Program
    {
        /// <summary>
        /// Calculate distance and angle between two points
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome! You may use this program to calculate " +
              "the distance between two points and the angle between those points.");

            //get first point x,y value
            Console.Write("Enter the x value of the first point: ");
            float x1 = float.Parse(Console.ReadLine());
            Console.Write("Enter the y value of the first point: ");
            float y1 = float.Parse(Console.ReadLine());

            //get second point x,y value
            Console.Write("Enter the x value of the second point: ");
            float x2 = float.Parse(Console.ReadLine());
            Console.Write("Enter the y value of the second point: ");
            float y2 = float.Parse(Console.ReadLine());

            //calculate distance between two points
            float deltaX = x2 - x1;
            float deltaY = y2 - y1;
            float distance = (float) Math.Sqrt((deltaX*deltaX) + (deltaY*deltaY));

            //calculate angle
            float angle = (float) (Math.Atan2(deltaY,deltaX)*180/Math.PI);

            //print the result
            Console.WriteLine("Distance between the two points is: " + distance);
            Console.WriteLine("Angle needs to be moved: " + angle);

        }
    }
}
