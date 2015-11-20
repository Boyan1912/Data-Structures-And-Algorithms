namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private IList<T> result = new List<T>();


        public void Sort(IList<T> collection)
        {

            if (collection.Count <= 1)
            {
                if (collection.Any())
                {
                    this.result.Add(collection.First());
                }

                return;
            }

            int pivotIndex = collection.Count / 2;
            var pivot = collection[pivotIndex];
            collection.RemoveAt(pivotIndex);

            var lessCollection = new List<T>();
            var greaterCollection = new List<T>();

            foreach (var item in collection)
            {
                if (pivot.CompareTo(item) >= 0)
                {
                    lessCollection.Add(item);
                }
                else
                {
                    greaterCollection.Add(item);
                }
            }

            if (lessCollection.Count <= 1)
            {
                if (lessCollection.Any())
                {
                    this.result.Add(lessCollection.First());
                    //Console.WriteLine(lessCollection.First());
                }
                this.result.Add(pivot);
                //Console.WriteLine(pivot);
                Sort(greaterCollection);
                return;
            }

            Sort(lessCollection);
            this.result.Add(pivot);
            //Console.WriteLine(pivot);

            if (greaterCollection.Count <= 1)
            {
                if (greaterCollection.Any())
                {
                    this.result.Add(greaterCollection.First());
                    //Console.WriteLine(greaterCollection.First());
                }

                return;
            }

            Sort(greaterCollection);
        }

        public void PrintResults()
        {
            Console.WriteLine(string.Join(" ", this.result));
        }
    }
}
