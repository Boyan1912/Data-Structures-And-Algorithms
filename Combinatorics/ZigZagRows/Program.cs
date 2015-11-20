namespace ZigZagRows
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            int[] numbers = new int[k];
            bool[] used = new bool[n];

            int count = 0;

            GenerateZigZagVariationsNoRepetitions(0, numbers, ref count, used);

            Console.WriteLine(count);
        }

        static void GenerateZigZagVariationsNoRepetitions(int index, int[] numbers, ref int count, bool[] used)
        {
            if (index >= numbers.Length)
            {
                bool isZigZag = true;
                int current = 0;
                while (current < numbers.Length - 1)
                {
                    if (numbers[current] <= numbers[current + 1])
                    {
                        isZigZag = false;
                        break;
                    }
                    current++;
                    if (current >= numbers.Length - 1) { break; }
                    if (numbers[current] >= numbers[current + 1])
                    {
                        isZigZag = false;
                        break;
                    }
                    current++;
                }
                if (isZigZag)
                {
                    count++;
                }
            }
            else
            {
                for (int i = 0; i < used.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        numbers[index] = i;
                        GenerateZigZagVariationsNoRepetitions(index + 1, numbers, ref count, used);
                        used[i] = false;
                    }
                }
            }
        }
    }
}
