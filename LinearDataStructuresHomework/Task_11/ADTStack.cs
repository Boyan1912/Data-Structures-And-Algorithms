namespace Task_11_13
{
    //12. Implement the ADT stack as auto-resizable array.
    //Resize the capacity on demand (when no space is available to add / insert a new element).

    public class ADTStack<T>
    {
        private T[] items;

        public ADTStack()
        {
            this.Items = new T[4];

        }

        public T[] Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public int Count { get; set; }

        public int Capacity 
        {
            get { return this.Items.Length; }
            
        }

        public void Push(T item)
        {
            this.Items[Count] = item;
            this.Count++;
        }

        public T Pop()
        {
            this.Count--;
            T item = this.Items[Count];
            this.Items[Count] = default(T);
            return item;
        }
        
        public void ResizeCapacity()
        {
            if (this.Items[this.Capacity - 1] != null)
            {
                var newCapacity = new T[this.Capacity * 2];
                newCapacity = (T[])this.Items.Clone();

                this.Items = newCapacity;
            }
        }

    }
}
