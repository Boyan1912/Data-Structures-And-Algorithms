namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            var collection = new SortableCollection<int>(new[] { 22, -2, 300, 11, 55, 33, 10, -15, 88, 101, 33, 0, 101, 44, 33 });
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("SelectionSorter result:");
            collection.Sort(new SelectionSorter<int>());
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, -2, 300, 11, 55, 33, 10, -15, 88, 101, 33, 0, 101, 44, 33 });
            Console.WriteLine("Quicksorter result:");
            var quickSorter = new Quicksorter<int>();
            collection.Sort(quickSorter);
            quickSorter.PrintResults();
            //collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            collection = new SortableCollection<int>(new[] { 22, -2, 300, 11, 55, 33, 10, -15, 88, 101, 33, 0, 101, 44, 33 });
            Console.WriteLine("MergeSorter result:");
            var mergeSort = new MergeSorter<int>();
            collection.Sort(mergeSort);
            mergeSort.ShowResults();
            //collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Linear search 101:");
            Console.WriteLine(collection.LinearSearch(101));
            Console.WriteLine();

            Console.WriteLine("Binary search 101:");
            Console.WriteLine(collection.BinarySearch(101));
            Console.WriteLine();


            collection = new SortableCollection<int>(new int[20]);
            for (int i = 1; i <= 20; i++)
            {
                collection.Items[i - 1] = i;
            }
            Console.WriteLine("All items before sorting:");
            collection.PrintAllItemsOnConsole();
            Console.WriteLine("Shuffle:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
            Console.WriteLine();

            Console.WriteLine("Shuffle again:");
            collection.Shuffle();
            collection.PrintAllItemsOnConsole();
        }
    }
}
