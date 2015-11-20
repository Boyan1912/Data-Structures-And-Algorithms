using System;

namespace _05
{
    class Program
    {

        public static void Main()
        {
            int k = 2;
            var array = new string[k];
            var strings = new string[] { "hi", "a", "b" };

            GenerateSubsets(array, strings, 0);
        }

        private static void GenerateSubsets(string[] subset, string[] original, int index)
        {
            if (index >= subset.Length)
            {
                Console.WriteLine(string.Join(", ", subset));
            }
            else
            {
                for (int i = 0; i < original.Length; i++)
                {
                    subset[index] = original[i];
                    GenerateSubsets(subset, original, index + 1);
                }
            }
        }
    }
}
