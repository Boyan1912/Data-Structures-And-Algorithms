namespace Task_11_13
{
    //11. Implement the data structure linked list.
    //Define a class ListItem<T> that has two fields: value (of type T) and NextItem (of type ListItem<T>).
    //Define additionally a class LinkedList<T> with a single field FirstElement (of type ListItem<T>).

    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public ListItem<T> NextItem
        {
            get { return this.nextItem; }
            set { this.nextItem = value; }
        }
    }
}
