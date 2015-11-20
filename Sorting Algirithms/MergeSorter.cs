namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        private Queue<IList<T>> listsQueue = new Queue<IList<T>>();

        public void Sort(IList<T> collection)
        {

            if (collection.Count <= 1)
            {
                this.listsQueue.Enqueue(new List<T>(collection));
                return;
            }

            int middle = (collection.Count + 1) / 2;

            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < middle; i++)
            {
                left.Add(collection[i]);
            }

            for (int i = middle; i < collection.Count; i++)
            {
                right.Add(collection[i]);
            }

            Sort(left);
            Sort(right);
        }

        public void ShowResults()
        {
            var result = FlattenList(this.listsQueue);
            Console.WriteLine(string.Join(" ", result));
        }

        private IList<T> FlattenList(Queue<IList<T>> queue)
        {
            if (queue.Count > 1)
            {
                var first = queue.Dequeue();
                var second = queue.Dequeue();

                var merged = Merge(first, second);
                queue.Enqueue(merged);
                FlattenList(queue);
            }

            return queue.FirstOrDefault();
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            var merged = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First().CompareTo(right.First()) <= 0)
                    {
                        merged.Add(left.First());
                        left.RemoveAt(0);
                    }
                    else
                    {
                        merged.Add(right.First());
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    merged.AddRange(new List<T>(left));
                    left.Clear();
                }
                else if (right.Count > 0)
                {
                    merged.AddRange(new List<T>(right));
                    right.Clear();
                }
            }

            return merged;
        }
    }
}
