namespace RowOfBalls
{
    using System;
    using System.Linq;

    class Program
    {
        
        static void Main()
        {

            string balls = "BYYBB"; //Console.ReadLine();

            var symbols = balls.ToCharArray().OrderBy(x => x).ToArray();

            //foreach (var c in symbols)
            //{
            //    Console.WriteLine(c);
            //}
            int count = 0;
            int countReversed = 0;
            GenerateArrangements(ref count, symbols, 0, 0);
            GenerateArrangements(ref countReversed, symbols.Reverse().ToArray(), 0, 0);
            Console.WriteLine(count + countReversed);
            //Console.WriteLine(countReversed);
        }

        static void GenerateArrangements(ref int count, char[] input, int currentIndex, int movesRight)
        {
            
            int nextIndex = currentIndex + 1;
            if (nextIndex >= input.Length)
            {
                //Console.WriteLine(string.Join(" ", input));
                //Console.WriteLine(count);
                BackTrack(input, ref currentIndex, movesRight - 1);
                movesRight = 0;
                //Console.WriteLine(string.Join(" ", input));
                string inputAsString = new string(input);
                currentIndex = inputAsString.IndexOf(input[currentIndex]);
                
                if (inputAsString.Substring(currentIndex).All(ch => ch.CompareTo(input[currentIndex]) == 0))
                {
                    //Console.WriteLine(string.Join(" ", input));
                    //Console.WriteLine(count);
                    return;
                }
                //GenerateArrangements(count, input, currentIndex + 1, movesRight);
            }
            else if (input[currentIndex] != input[nextIndex])
            {
                Swap(ref input[currentIndex], ref input[nextIndex]);
                count++;
                movesRight++;
            }
            //Console.WriteLine(string.Join(" ", input));
            //Console.WriteLine(count);
            GenerateArrangements(ref count, input, currentIndex + 1, movesRight);
        }

        private static void BackTrack(char[] input, ref int position, int movesRight)
        {
            for (int i = 0; i < movesRight; i++)
            {
                Swap(ref input[position], ref input[position - 1]);
                position--;
            }
        }

        private static void Swap(ref char current, ref char next)
        {
            char old = current;
            current = next;
            next = old;
        }
    }
}
