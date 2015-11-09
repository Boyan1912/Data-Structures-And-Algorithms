namespace PriorityQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class PriorityQueue<T>
        where T : IComparable
    {
        
        public PriorityQueue()
        {
            this.Items = new T[1];
        }

        public T[] Items { get; set; }
        
        public T TopItem
        {
            get { return this.Items[0]; }
            set { this.Items[0] = value; }
        }

        public T LastItem
        {
            get { return this.Items[this.Items.Length - 1]; }
            set { this.Items[this.Items.Length - 1] = value; }
        }

        public int Count
        {
            get { return this.Items.Length; }
        }

        public T this[int index]
        {
            get { return this.Items[index]; }
            set { this.Items[index] = value; }
        }

        public void Enqueue(params T[] elements)
        {
            int countNewItems = elements.Length;
            this.EnlargeSize(countNewItems);

            for (int i = 0; i < countNewItems; i++)
            {
                int index = this.Items.Length - countNewItems + i;

                this.Items[index] = elements[i];

                this.ReOrderElementsUpwards(index);
            }
        }

        private void EnlargeSize(int length)
        {
            T[] newSize = new T[this.Items.Length + length];

            for (int i = 0; i < this.Items.Length; i++)
            {
                newSize[i] = this.Items[i];
            }

            this.Items = newSize;
        }

        public T Dequeue()
        {
            T temp = this.TopItem;
            this.TopItem = this.LastItem;
            this.DownSize(1);
            this.ReOrderElementsDownwards(0);

            return temp;
        }

        private void DownSize(int cut)
        {
            T[] downsized = new T[this.Items.Length - cut];

            for (int i = 0; i < downsized.Length; i++)
            {
                downsized[i] = this.Items[i];
            }

            this.Items = downsized;
        }

        public void RemoveAt(int index)
        {
            this.Items[index] = this.LastItem;
            this.DownSize(1);
            this.ReOrderElementsDownwards(index);
            this.ReOrderElementsUpwards(index);
        }

        public bool HasChildrenOrSibling(int index)
        {
            if (index >= this.Items.Length - 1)
            {
                return false;
            }

            return true;
        }

        public int GetDepth(int index)
        {
            index += 1;
            int depth = 0;
            int upperLimit = 1;
            while (true)
            {
                int downLimit = upperLimit;
                upperLimit *= 2;
                depth++;
                if (index >= downLimit && index < upperLimit)
                {
                    break;
                }
            }

            return depth;
        }

        private void ReOrderElementsDownwards(int index = 0)
        {
            if (this.HasChildrenOrSibling(index))
            {
                int leftChildIndex = index + 1;
                this.SwapIfNeeded(index, leftChildIndex);

                if (this.HasChildrenOrSibling(leftChildIndex))
                {
                    int rightChildIndex = leftChildIndex + 1;
                    this.SwapIfNeeded(index, rightChildIndex);
                }
            }
        }

        private void ReOrderElementsUpwards(int index)
        {
            int parentIndex = index / 2;
            this.SwapIfNeeded(parentIndex, index);
        }

        private void SwapIfNeeded(int index, int childIndex)
        {
            if (this.Items[childIndex].CompareTo(this.Items[index]) > 0)
            {
                T temp = this.Items[index];
                this.Items[index] = this.Items[childIndex];
                this.Items[childIndex] = temp;

                this.ReOrderElementsDownwards(childIndex);
                this.ReOrderElementsUpwards(index);
            }
        }

        public void PrintAll()
        {
            int level = this.GetDepth(0);
            var levelItems = new List<T>();
            int padding = 30;

            for (int i = 0; i < this.Items.Length; i++)
            {
                levelItems.Add(this.Items[i]);
                
                if (this.GetDepth(i + 1) == level + 1)
                {
                    Console.Write("Level: {0}   ".PadRight(10, '.'), level);
                    Console.WriteLine(string.Join(" | ", levelItems).PadLeft(padding +=  level, '.'));
                    level++;
                    levelItems.Clear();
                }
            }
            Console.Write("Level: {0}   ".PadRight(10, '.'), level);
            Console.WriteLine(string.Join(" | ", levelItems).PadLeft(padding + level, '.'));
        }
        
    }
}
