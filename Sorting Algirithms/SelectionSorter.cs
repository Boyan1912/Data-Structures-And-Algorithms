namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    //Complexity - n ^ 2 - for each element goes throughout the whole collection
    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                int indexOfMin = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[indexOfMin].CompareTo(collection[j]) > 0)
                    {
                        indexOfMin = j;
                    }
                }
                if (!collection[indexOfMin].Equals(collection[i]))
                {
                    Swap(collection, i, indexOfMin);
                }
            }
        }

        public void Swap(IList<T> collection, int replaceIndex, int indexMinValue)
        {
            T temp = collection[replaceIndex];
            collection[replaceIndex] = collection[indexMinValue];
            collection[indexMinValue] = temp;
        }
    }
}
