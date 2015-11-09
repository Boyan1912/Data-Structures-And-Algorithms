namespace Task5
{
    using System.Collections.Generic;
    using Task4;

    public class HashedSet<T>
    {
        private HashTable<int, T> data; 

        public HashedSet()
        {
            this.Data = new HashTable<int, T>();
        }
        
        public HashTable<int, T> Data
        {
            get { return this.data; }
            set { this.data = value; }
        }

        public int Count
        {
            get { return this.Data.Count; }
        }

        public bool Contains(T element)
        {
            int hash = this.GetHash(element);
            return this.Data.Keys.Contains(hash);
        }


        public int GetHash(T element)
        {
            return this.Data.GetHash(element);
        }

        public void Add(T element)
        {
            int hash = this.GetHash(element);

            if (!this.Contains(element))
            {
                this.Data.Add(hash, element);
            }
        }

        public T Find(T element)
        {
            int hash = this.GetHash(element);

            return this.Data.Find(hash);
        }

        public void Remove(T element)
        {
            int hash = this.GetHash(element);

            this.Data.Remove(hash);
        }

        public void Clear()
        {
            this.Data.Clear();
        }

        public void Union(IEnumerable<T> elements)
        {
            foreach (var elem in elements)
            {
                this.Add(elem);
            }
        }

        public void Intersect(IEnumerable<T> elements)
        {
            var result = new HashedSet<T>();

            foreach (var elem in elements)
            {
                if (this.Contains(elem))
                {
                    result.Add(elem);
                }
            }

            this.Data = result.Data;
        }
    }
}
