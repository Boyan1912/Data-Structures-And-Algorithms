using System;

namespace _04
{
    class Program
    {
        static void Main()
        {



            GeneratePermutations(0, new int[] { 1,2,3});


        }

        static void GeneratePermutations(int startIndex, int[] numbers)
        {
            int[] permutations = new int[numbers.Length];
            
            if (startIndex > numbers.Length)
            {
                return;
            }

            permutations[startIndex % numbers.Length] = numbers[startIndex % numbers.Length];

            for (int i = 1; i <= numbers.Length; i++)
            {
                permutations[(startIndex + i) % numbers.Length] = i;
            }
            Console.WriteLine(string.Join(" ", permutations));
            GeneratePermutations(startIndex + 1, permutations);
        }


    }
}
