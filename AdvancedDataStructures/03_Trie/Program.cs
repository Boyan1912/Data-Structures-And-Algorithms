namespace Trie
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {

            string text = "computer science, a trie, also called digital tree and sometimes radix tree or prefix tree (as they can be searched by prefixes), is an ordered tree data structure that is used to store a dynamic set or associative array where the keys are usually strings. Unlike a binary search tree, no node in the tree stores the key associated with that node; instead, its position in the tree defines the key with which it is associated. All the descendants of a node have a common prefix of the string associated with that node, and the root is associated with the empty string. Values are not necessarily ";

            var words = text.Split(new[] { ' ', ',', '.', ':', '\t', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var trie = new Trie();
            foreach (string word in words)
            {
                trie.PopulateTrieFromText(word);
            }
            foreach (var n in trie.AllNodes)
            {
                Console.WriteLine(n);
            }
        }
    }
}
