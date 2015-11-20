using System;

namespace _06
{
    class Program
    {
        static void Main(string[] args)
        {

            int k = 3;
            string[] arr = new string[] { "test", "rock", "fun", "something" };
            GenerateSubsets(new string[k], 0, arr, arr.Length);
        }

        static void GenerateSubsets(string[] subsets, int startIndex, string[] input, int endIndex)
        {
            if (startIndex == subsets.Length)
            {
                Console.WriteLine(string.Join(" ", subsets));
                return;
            }
            for (int i = startIndex; i < endIndex; i++)
            {
                subsets[startIndex % subsets.Length] = input[i % input.Length];
                GenerateSubsets(subsets, startIndex + 1, input, endIndex + 1);
            }
        }

    }
}
