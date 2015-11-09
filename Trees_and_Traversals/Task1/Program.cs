namespace Task1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {

            int N = int.Parse(Console.ReadLine());

            Tree tree = new Tree();
            for (int i = 0; i < N - 1; i++)
            {
                var input = Console.ReadLine().Trim().Split(' ');
                int parentValue = int.Parse(input[0]);
                int childValue = int.Parse(input[1]);
                tree.AddNodes(new Node(parentValue), new Node(childValue));
                var parentNode = tree.GetNodeByValue(parentValue);
                var childNode = tree.GetNodeByValue(childValue);
                parentNode.AddChildren(childNode);
                
            }

            Console.WriteLine("Root Node: {0}", tree.GetRootNode().Value);
            Console.WriteLine("All leaf nodes: {0}", string.Join(", ", tree.GetAllLeaves().Select(x => x.Value)));
            Console.WriteLine("All middle nodes: {0}", string.Join(", ", tree.GetAllMiddleNodes().Select(x => x.Value)));

            var longestPath = tree.FindPaths(tree.GetRootNode(), new Stack<int>(), new List<HashSet<int>>())
                                    .OrderByDescending(x => x.Count)
                                    .FirstOrDefault();

            var stack = new Stack<int>();
            foreach (var val in longestPath)
            {
                stack.Push(val);
            }

            Console.Write("Longest Path: ");
            Console.WriteLine(string.Join(" -> ", stack));

            int findSum = 9;
            var path = tree.FindPathsWithGivenSum(findSum); 

            foreach (var p in path)
            {
                Console.Write("Path with the sum of {0}: ", findSum);
                Console.Write(string.Join(" <- ", p));
                Console.WriteLine();
            }

        }
    }
}
