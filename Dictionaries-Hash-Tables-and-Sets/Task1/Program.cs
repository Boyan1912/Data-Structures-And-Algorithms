namespace Task1
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            //Write a program that counts in a given array of double values the number of occurrences of each value.Use Dictionary< TKey,TValue >.

            //Example: array = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5}
            //-2.5-> 2 times
            //3-> 4 times
            //4-> 3 times

            var array = new double[]{ 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dict = new Dictionary<double, int>();
            foreach (double value in array)
            {
                if (!dict.ContainsKey(value))
                {
                    dict[value] = 1;
                }
                else
                {
                    dict[value]++;
                }
            }

            foreach (var val in dict)
            {
                Console.WriteLine("{0} --> {1}", val.Key, val.Value);
            }
        }
    }
}
