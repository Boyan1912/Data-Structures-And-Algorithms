namespace Task4
{
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<K, T>
    {
        private LinkedList<KeyValuePair<K, T>>[] data;

        public HashTable()
        {
            this.Data = new LinkedList<KeyValuePair<K, T>>[16];
        }

        public int Count
        {
            get
            {
                int count = 0;
                foreach (var element in this.Data)
                {
                    if (element != null)
                    {
                        count++;
                        var node = element.First;
                        while (node.Next != null)
                        {
                            count++;
                            node = node.Next;
                        }
                    }
                }

                return count;
            }
        }

        public LinkedList<KeyValuePair<K, T>>[] Data
        {
            get
            {
                int count = 0;
                foreach (var element in this.Data)
                {
                    if (element != null)
                    {
                        count++;
                    }
                }

                double occupiedCapacity = count / this.data.Length;
                if (occupiedCapacity >= 0.75)
                {
                    this.ResizeCapacity();
                }

                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        public T this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                this.Add(key, value);
            }
        }

        public IList<K> Keys
        {
            get
            {
                var keys = new List<K>();

                foreach(var list in this.Data)
                {
                    var node = list.First;
                    while (node != null)
                    {
                        keys.Add(node.Value.Key);
                        node = node.Next;
                    }
                }

                return keys;
            }
        }

        private void ResizeCapacity()
        {
            var newCapacity = new LinkedList<KeyValuePair<K, T>>[this.Data.Length * 2];

            for (int i = 0; i < this.Data.Length; i++)
            {
                if (this.Data[i] != null)
                {
                    var node = this.Data[i].First;
                    var list = new LinkedList<KeyValuePair<K, T>>();
                    list.AddFirst(node);
                    int index = this.GetHash(node.Value.Key);
                    newCapacity[index] = list;

                    while (node.Next != null)
                    {
                        node = node.Next;
                        index = this.GetHash(node.Value.Key);
                        var linkedList = new LinkedList<KeyValuePair<K, T>>();
                        linkedList.AddFirst(node);
                        newCapacity[index] = linkedList;
                    }

                }
            }

            this.Data = newCapacity;
        }

        public int GetHash(object value)
        {
            return value.GetHashCode() % this.Data.Length;
        }

        public void Add(K key, T value)
        {
            int index = this.GetHash(key);
            KeyValuePair<K, T> keyValue = new KeyValuePair<K, T>(key, value);

            if (this.Data[index] == null)
            {
                var list = new LinkedList<KeyValuePair<K, T>>();
                list.AddFirst(new KeyValuePair<K, T>());
                this.Data[index] = list;
            }
            else
            {
                this.Data[index].AddLast(keyValue);
            }
            
        }

        public T Find(K key)
        {
            int index = this.GetHash(key);

            return this.Data[index].FirstOrDefault(x => this.GetHash(x.Key) == this.GetHash(key)).Value;
        }
        
        public void Remove(K key)
        {
            int index = this.GetHash(key);

            KeyValuePair<K, T> keyValue = this.Data[index].FirstOrDefault(x => this.GetHash(x.Key) == this.GetHash(key));

            this.Data[index].Remove(keyValue);
        }

        public void Clear()
        {
            var clearedData = new LinkedList<KeyValuePair<K, T>>[16];
            this.Data = clearedData;
        }
        
    }
}
