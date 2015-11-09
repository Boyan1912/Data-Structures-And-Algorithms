namespace Tasks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            List<int> consoleNumbers = GetNumbersListFromConsole();
            List<int> randomList = GetRandomNumbersList(10, -100, 100);

            // 01. Write a program that reads from the console a sequence of positive integer numbers.

            //The sequence ends when empty line is entered.
            //Calculate and print the sum and average of the elements of the sequence.
            //Keep the sequence in List<int>.

            CalcSumAndAverage(consoleNumbers);

            // 02. Write a program that reads N integers from the console and reverses them using a stack.
            //Use the Stack<int> class.

            PrintNumbersInReverse();

            //03. Write a program that reads a sequence of integers (List<int>) ending with an empty line and sorts them in an increasing order.

            PrintSortedList();

            //04. Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
            //    Write a program to test whether the method works correctly.

            PrintLongestSubsequenceOfEqualNumbers(consoleNumbers);

            //05. Write a program that removes from given sequence all negative numbers.

            PrintNumbersList(randomList);
            RemoveNegativeNumbers(randomList);

            //06. Write a program that removes from given sequence all numbers that occur odd number of times.

            List<int> list = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            RemoveOddTimesOccuringNumbers(list);

            //07. Write a program that finds in given array of integers (all belonging to the range [0..1000]) how many times each of them occurs.

            int[] numbers = new[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            CountAppearences(numbers);

            //08. *The majorant of an array of size N is a value that occurs in it at least N/2 + 1 times.

            //Write a program to find the majorant of given array (if exists).
            //Example:
            int[] arr = new[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            FindMajorant(arr);

            // 09. We are given the following sequence:

            //S1 = N;
            //S2 = S1 + 1;
            //S3 = 2*S1 + 1;
            //S4 = S1 + 2;
            //S5 = S2 + 1;
            //S6 = 2*S2 + 1;
            //S7 = S2 + 2;
            //...
            //Using the Queue<T> class write a program to print its first 50 members for given N.
            //Example: N=2 → 2, 3, 5, 4, 4, 7, 5, 6, 11, 7, 5, 9, 6, ...

            PrintQueueMembers(50, 2);

            //10. We are given numbers N and M and the following operations:

            //N = N+1
            //N = N+2

            //N = N*2

            //Write a program that finds the shortest sequence of operations from the list above that starts from N and finishes in M.
            //Hint: use a queue.
            //Example: N = 5, M = 16
            //Sequence: 5 → 7 → 8 → 16

            var q = GetPossibleOperations(new List<Func<int, int>>() { MultiplyByTwo, AddOne, AddTwo });
            while (q.Count > 0)
            {
                FindShortestSequenceOfOperations(5, 16, q, new Queue<int>());
                q.Dequeue();
            }
        }

        private static Queue<Func<int, int>> GetPossibleOperations(List<Func<int, int>> operations)
        {
            var result = new Queue<Func<int, int>>();

            for (int i = 0; i < operations.Count; i++)
            {
                result.Enqueue(operations[i]);
                for (int j = 0; j < operations.Count; j++)
                {
                    if (i != j)
                    {
                        result.Enqueue(operations[j]);
                    }
                }
            }
            return result;
        }

        private static void FindShortestSequenceOfOperations(int n, int m, Queue<Func<int, int>> operations, Queue<int> sequence)
        {
            if (operations.Count < 1) { return; }

            var ops = new Queue<Func<int, int>>(operations);
            if (!sequence.Contains(n)) { sequence.Enqueue(n); }
            int result = ops.Dequeue()(n);
            if (result <= m) { sequence.Enqueue(result); }
            
            if (result == m)
            {
                int depth = sequence.Count - 1;
                while (sequence.Count > 0) { Console.Write(sequence.Dequeue() + " --> "); }
                Console.Write(depth + " operations");
                Console.WriteLine();
                return;
            }

            if (result > m * 2) { return; }
            
            if (result > m)
            {
                result = n;
            }
            
            FindShortestSequenceOfOperations(result, m, ops, sequence);
        }

        private static int AddOne(int input)
        {
            return input + 1;
        }

        private static int AddTwo(int input)
        {
            return input + 2;
        }

        private static int MultiplyByTwo(int input)
        {
            return input * 2;
        }

        private static void PrintQueueMembers(int count, int n)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i = 0; i < count; i++)
            {
                int current = queue.Dequeue();
                Console.Write("{0}, ", current);

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current + 1);
                queue.Enqueue(current + 2);
            }
        }

        private static void FindMajorant(int[] arr)
        {
            int majorantRequirement = arr.Length / 2 + 1;
            
            for (int i = 0; i < arr.Length; i++)
            {
                int count = arr.Count(x => x == arr[i]);
                if (count >= majorantRequirement)
                {
                    Console.WriteLine("Majorant: " + arr[i]);
                    return;
                }
            }
            Console.WriteLine("No majorant");
        }

        private static void CountAppearences(int[] numbers)
        {
            Dictionary<int, string> result = new Dictionary<int, string>(); 
            for (int i = 0; i < numbers.Length; i++)
            {
                int appearances = numbers.Count(x => x == numbers[i]);
                if (!result.ContainsKey(numbers[i]))
                {
                    result[numbers[i]] = string.Format("{0} - {1}", numbers[i], appearances);
                }
            }
            foreach (var res in result)
            {
                Console.WriteLine(res.Value);
            }
        }

        private static void RemoveOddTimesOccuringNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int count = 0;
                int checkNumber = numbers[i];
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (checkNumber == numbers[j])
                    {
                        count++;
                    }
                }
                if (count % 2 == 1)
                {
                    numbers.RemoveAll(x => x == checkNumber);
                }
            }

            PrintNumbersList(numbers);
        }

        private static void PrintNumbersList(List<int> randomList)
        {
            Console.WriteLine(string.Join(", ", randomList));
        }

        private static List<int> GetRandomNumbersList(int count, int rangeMin, int rangeMax)
        {
            List<int> numbers = new List<int>();
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(rand.Next(rangeMin, rangeMax));
            }
            return numbers;
        }

        private static void PrintLongestSubsequenceOfEqualNumbers(List<int> numbers)
        {
            int counter = 0;
            int index = 0;
            int bestCount = 0;
            int bestNumber = 0;
            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[index] == numbers[i])
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
                if (counter >= bestCount)
                {
                    bestCount = counter;
                    bestNumber = numbers[i];
                }
                index++;
            }

            List<int> result = new List<int>();
            for (int i = 0; i <= bestCount; i++)
            {
                result.Add(bestNumber);
            }
            Console.WriteLine("Longest subsequence of equal numbers: ");
            PrintNumbersList(result);
        }

        private static List<int> GetNumbersListFromConsole()
        {
            List<int> numbers = new List<int>();
            foreach (string num in Console.ReadLine().Trim().Split(' '))
            {
                numbers.Add(int.Parse(num));
            }
            return numbers;
        }

        private static void PrintSortedList()
        {

            List<int> numbers = new List<int>();
            foreach (string num in Console.ReadLine().Trim().Split(' '))
            {
                int number = int.Parse(num);
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (number <= numbers[i])
                    {
                        numbers.Insert(i, number);
                        break;
                    }
                    else if (number > numbers[i] && i >= numbers.Count - 1)
                    {
                        numbers.Add(number);
                        break;
                    }
                }

                if (numbers.Count == 0)
                {
                    numbers.Add(number);
                }
            }
            PrintNumbersList(numbers);
        }

        private static void PrintNumbersInReverse()
        {
            Stack<int> numbers = new Stack<int>();
            foreach (string num in Console.ReadLine().Trim().Split(' '))
            {
                numbers.Push(int.Parse(num));
            }
            while (numbers.Count > 0)
            {
                Console.Write(numbers.Pop() + " ");
            }
        }

        private static void CalcSumAndAverage(List<int> input)
        {
            int sum = 0;
            foreach (int number in input)
            {
                sum += number;
            }

            double average = (double)sum / (double)input.Count;
            Console.WriteLine("Sum: {0}\nAverage: {1}", sum, average);
        }

        private static void RemoveNegativeNumbers(List<int> numbers)
        {
            numbers.RemoveAll(x => x < 0);
            Console.WriteLine("The list without negative values:");
            PrintNumbersList(numbers);
        }
    }
}
