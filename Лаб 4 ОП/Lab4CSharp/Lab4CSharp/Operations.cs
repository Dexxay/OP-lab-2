using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4CSharp
{
    class Operations
    {
        public static double InputTime()
        {
            Console.Write("Enter t in seconds: ");
            while (true)
            {
                string input = Console.ReadLine();
                if (double.TryParse(input, out double time) && time > 0)
                {
                    return time;
                }
                else
                {
                    Console.Write("Wrong input. Try again: ");
                }
            }
        }

        public static int InputNumber(string message)
        {
            Console.Write($"Enter {message}: ({message} > 1) ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int number) && number > 1)
                {
                    return number;
                }
                else
                {
                    Console.Write("Wrong input. Try again: ");
                }
            }
        }

        public static void ShowObjects(MovingPointParticle[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i + 1})");
                array[i].DisplayObject();
            }
        }

        public static void ShowCoordinates(MovingPointParticle[] array, double t)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i + 1})");
                array[i].DisplayCoordinates(t);
            }
        }

        public static double ReturnMaxDistance(MovingPointParticle[] array, out int first, out int second, double t)
        {
            first = 0;
            second = 1;
            double maxDistance = array[0].GetDistance(array[1].GetCoordinates(t, out double y), y);
            for (int o = 0; o < array.Length - 1; o++)
            {
                for (int i = o + 1; i < array.Length; i++)
                {
                    double temp = array[o].GetDistance(array[i].GetCoordinates(t, out y), y);
                    if (temp > maxDistance)
                    {
                        maxDistance = temp;
                        first = o;
                        second = i;
                    }
                }
            }
            return maxDistance;
        }
    }
}
