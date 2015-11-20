namespace _03
{
    using System;

    class Program
    {
        //    Modify the previous program to skip duplicates:

        //n=4, k=2 → (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)

        static void Main()
        {
            int n = 5;
            int k = 3;
            int[] combinationsSet = new int[k];

            GenerateCombinations(combinationsSet, 0, 0, n);
        }

        static void GenerateCombinations(int[] combinations, int currentIndex, int start, int end)
        {
            if (currentIndex == combinations.Length)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }
            for (int i = start; i <= end; i++)
            {
                combinations[currentIndex] = i;
                GenerateCombinations(combinations, currentIndex + 1, i + 1, end);
            }
        }
    }
}
