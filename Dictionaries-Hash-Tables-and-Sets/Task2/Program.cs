namespace Task2
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            //Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.Example:

            //{ C#, SQL, PHP, PHP, SQL, SQL } -> {C#, SQL}

            var array = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            var dict = new Dictionary<string, int>();

            foreach (string word in array)
            {
                if (!dict.ContainsKey(word))
                {
                    dict[word] = 1;
                }
                else
                {
                    dict[word]++;
                }

            }

            foreach (var val in dict)
            {
                if (val.Value % 2 == 1)
                {
                    Console.WriteLine(val.Key);
                }
            }
        }
    }
}
