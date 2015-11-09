namespace Task_11_13
{
    //13. Implement the ADT queue as dynamic linked list.
    //Use generics (LinkedQueue<T>) to allow storing different data types in the queue.

    public class LinkedQueue<T>
    {
        private LinkedList<T> currentItem;

        public LinkedQueue()
        {
            this.CurrentItem = new LinkedList<T>();
        }

        public LinkedList<T> CurrentItem
        {
            get { return this.currentItem; }
            set { this.currentItem = value; }
        }

        public int Count { get; set; }
        
        public void Enqueue(T item)
        {
            this.CurrentItem.FirstElement.Value = item;
        }

        public T Dequeue()
        {
            T item = this.CurrentItem.FirstElement.Value;
            this.CurrentItem.FirstElement.Value = default(T);
            return item;
        }

    }
}
