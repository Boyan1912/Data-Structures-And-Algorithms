using System;

namespace _02
{
    class Program
    {
    //    Write a recursive program for generating and printing all the combinations with duplicatesof k elements from n-element set.Example:

    //n= 3, k= 2 → (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)


        static void Main()
        {
            int n = 3;
            int k = 2;
            int[] combinationsSet = new int[k];

            GenerateCombinations(combinationsSet, 0, n);
        }

        static void GenerateCombinations(int[] combinations, int currentIndex, int n)
        {
            if (currentIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }
            for (int i = 1; i <= n; i++)
            {
                combinations[currentIndex] = i;
                GenerateCombinations(combinations, currentIndex + 1, n);
            }
        }

    }
}
