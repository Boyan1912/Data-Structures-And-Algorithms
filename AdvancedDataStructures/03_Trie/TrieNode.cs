//namespace Trie
//{
//    using System.Collections.Generic;
//    using System.Linq;
//    using Wintellect.PowerCollections;

//    public class TrieNode
//    {
//        private string prefix;
//        private string value;

//        public TrieNode(char symbol, int id, TrieNode parent)
//            : this(symbol, id)
//        {
//            this.Parent = parent;
//            this.Prefix = this.Parent.Value.Trim();
//            this.Value = this.Prefix + this.Symbol;
//            this.Parent.Trie.AddTrieNode(this);
//        }

//        public TrieNode(char symbol, int id)
//            : this()
//        {
//            symbol = char.ToLower(symbol);
//            this.Symbol = symbol;
//            this.Id = id;
//        }

//        public TrieNode()
//        {
//            this.ChildrenIds = new HashSet<int>();
//            this.Children = new List<TrieNode>();
//        }

//        public Trie Trie { get; set; }

//        public int Id { get; set; }

//        public char Symbol { get; set; }

//        public string Prefix
//        {
//            get { return this.prefix; }
//            set { this.prefix = value; }
//        }

//        public string Value
//        {
//            get { return this.value; }
//            set { this.value = value; }
//        }

//        public TrieNode Parent { get; set; }

//        public HashSet<int> ChildrenIds { get; set; }

//        public List<TrieNode> Children { get; set; }

//        public bool HasParent
//        {
//            get { return !string.IsNullOrEmpty(this.Prefix); }
//        }

//        public bool HasChildren
//        {
//            get { return this.ChildrenIds.Count > 0; }
//        }

//        //public void AddChildren(params TrieNode[] children)
//        //{
//        //    for (int i = 0; i < children.Length; i++)
//        //    {
//        //        this.ChildrenIds.Add(children[i].Id);
//        //        this.Children.Add(children[i]);
//        //    }
//        //}

//        public override string ToString()
//        {
//            return this.Value;
//        }

//        public override bool Equals(object other)
//        {
//            return this.Value.Equals((other as TrieNode).Value);
//        }
//    }
//}