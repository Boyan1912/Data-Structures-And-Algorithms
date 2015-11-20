namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            foreach (var thing in this.Items)
            {
                if (item.CompareTo(thing) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool BinarySearch(T item, int min = -1, int max = -1, bool itemsSorted = false)
        {

            min = min < 0 ? 0 : min;
            max = max < 0 ? this.Items.Count : max;

            if (!itemsSorted)
            {
                this.Sort(new SelectionSorter<T>());
            }

            if (max < min)
            {
                return false;
            }
            
            int middle = (max + min) / 2;

            if (this.Items[middle].CompareTo(item) > 0)
            {
                BinarySearch(item, min, middle - 1, true);
            }
            else if (this.Items[middle].CompareTo(item) < 0)
            {
                BinarySearch(item, middle + 1, max, true);
            }

            return true;
        }

        public void Shuffle()
        {
            //Fisher–Yates shuffle
            var random = new Random();
            bool[] usedIndexes = new bool[this.Items.Count];
            int endIndex = this.Items.Count - 1;
            for (int i = endIndex; i > 0; i--)
            {
                int currentIndex = endIndex - i;
                int randIndex = random.Next(0, endIndex + 1);
                while (usedIndexes[randIndex])
                {
                    randIndex++;
                    if (randIndex >= endIndex)
                    {
                        randIndex %= endIndex;   // in order not to exceed the boundaries of the array
                    }
                }
                Swap(this.Items, currentIndex, randIndex);
                usedIndexes[randIndex] = true;
            }
            // Algotithms complexity is O(n) since it goes only once throughout the whole collection. If the random index happens to have been used the algorithm goes to the next available index instead of checking the whole collection which would make the complexity n^2.
        }

        private void Swap(IList<T> items, int currentIndex, int randIndex)
        {
            T temp = items[currentIndex];
            items[currentIndex] = items[randIndex];
            items[randIndex] = temp;
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
