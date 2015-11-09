//namespace Trie
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using Wintellect.PowerCollections;

//    public class Trie
//    {
//        public Trie()
//        {
//            this.CharPointers = new MultiDictionary<char, TrieNode>(false);
//            this.NodeIds = 0;
//            this.MainNode = new TrieNode();
//            this.MainNode.Id = 0;
//            this.MainNode.Prefix = "";
//            this.MainNode.Value = "";
//            this.MainNode.Symbol = ' ';
//            this.MainNode.Trie = this;
//            this.AllNodes = new HashSet<TrieNode>();

//        }

//        public int NodeIds { get; set; }

//        public TrieNode MainNode { get; set; }

//        public HashSet<TrieNode> AllNodes { get; set; }

//        public MultiDictionary<char, TrieNode> CharPointers { get; set; }

//        public TrieNode GetTrieNode(char symbol, TrieNode parent = null)
//        {
//            if (parent == null)
//            {
//                parent = this.MainNode;
//            }
//            bool nodeExists = this.CheckIfNodeExists(symbol);
//            if (nodeExists)
//            {
//                return this.AllNodes.FirstOrDefault(n => n.Symbol == symbol);
//            }
            
//            var node = new TrieNode(symbol, this.NodeIds++, parent);
//            return node;
//        }

//        private bool CheckIfNodeExists(char symbol)
//        {
//            return this.AllNodes.Any(n => n.Symbol == symbol);
//        }

//        public void AddTrieNode(TrieNode newTrieNode)
//        {
//            newTrieNode.Trie = this;
//            this.CharPointers.Add(newTrieNode.Symbol, newTrieNode);
//            this.AllNodes.Add(newTrieNode);
//        }

//        public void PopulateTrieFromText(string word)
//        {
//            word = word.ToLower();

//            for (int i = 0; i < word.Length; i++)
//            {
//                //var relevantNodes = this.CharPointers
//                //                    .Where(ch => ch.Key == word[i])
//                //                    .Select(x => x.Value
//                //                        .Where(n => n.Prefix.Equals(word.Substring(0, i + 1))));

//                List<TrieNode> relevantNodes = GetRelevantNodes(word.Substring(0, i + 1));

//                bool newNodeNeeded = relevantNodes.Count < 1;
//                if (newNodeNeeded)
//                {
//                    TrieNode correctSymbolNewNode = GetCorrectSymbolNewNode(word[Math.Max(0, i - 1)]);
//                    if (correctSymbolNewNode != null)
//                    {
//                        var newTrieNode = this.GetTrieNode(word[i], correctSymbolNewNode);
//                        this.AddTrieNode(newTrieNode);
//                        continue;
//                    }
//                    else
//                    {
//                        var newNode = this.GetTrieNode(word[i]);
//                        this.AddTrieNode(newNode);
//                        continue;
//                    }
//                }
//                else
//                {

//                }
//            }
//        }

//        private TrieNode GetCorrectSymbolNewNode(char letter)
//        {
//            return this.AllNodes
//                       .Where(n => n.Symbol == letter && !n.HasParent)
//                       .FirstOrDefault();
//        }

//        private List<TrieNode> GetRelevantNodes(string subString)
//        {
//            return this.AllNodes
//                       .Where(n => n.Prefix.Equals(subString) && !string.IsNullOrEmpty(subString))
//                       .ToList();
//        }
//    }
//}
