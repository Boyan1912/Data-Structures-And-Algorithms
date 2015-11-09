namespace Task_11_13
{
    public class LinkedList<T>
    {
        private ListItem<T> firstElement;





        public ListItem<T> FirstElement 
        {
            get { return this.firstElement; }
            set { this.firstElement = value; }
        }
    }
}
