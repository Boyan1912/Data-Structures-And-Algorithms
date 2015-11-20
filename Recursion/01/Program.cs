using System;
using System.Linq;

namespace _01
{
    class Program
    {
        //        Write a recursive program that simulates the execution of n nested loopsfrom 1 to n.

        //    Examples:

        //         1 1
        // n= 2->  1 2
        //         2 1
        //         2 2

        //         1 1 1
        //         1 1 2
        //         1 1 3
        //         1 2 1
        // n= 3->  ...
        //         3 2 3
        //         3 3 1
        //         3 3 2
        //         3 3 3


        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            ExecuteNLoops(n, n-1, new int[n]);
        }

        static void ExecuteNLoops(int n, int index, int[] arr)
        {
            //if (arr.All(x => x == n))
            //{
            //    return;
            //}
            if (index < 0)
            {
                return;
            }
            arr[index]++;

            if (arr[index] == n)
            {
                index--;
            }
            Console.WriteLine(string.Join(" ", arr));

            ExecuteNLoops(n, index, arr);
        }
    }
}
