namespace _03
{
    using System.Collections;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {

        public MultiDictionary<K1, MultiDictionary<K2, T>> Values { get; set; }
        
        public void Add(K1 keyCollection, K2 key, T value)
        {
            var dict = new MultiDictionary<K2, T>(true);
            dict.Add(key, value);
            this.Values.Add(keyCollection, dict);
        }


    }
}
