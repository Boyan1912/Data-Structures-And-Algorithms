namespace Task1
{
    using System.Collections.Generic;
    using System.Linq;
    public class Tree
    {
        //private List<HashSet<int>> paths;

        public Tree()
        {
            this.Nodes = new HashSet<Node>();
            //this.Paths = new List<HashSet<int>>();
            //this.FindPaths(this.GetRootNode(), new HashSet<int>());
        }

        public HashSet<Node> Nodes { get; set; }

        //public List<HashSet<int>> Paths
        //{
        //    get
        //    {
                
        //        return this.paths;
        //    }
        //    set
        //    {
                
        //        this.paths = value;
        //    }

        //}

        public void AddNodes(params Node[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (this.GetNodeByValue(nodes[i].Value) == null)
                {
                    this.Nodes.Add(nodes[i]);
                }
            }
        }

        public Node GetRootNode()
        {
            return this.Nodes.FirstOrDefault(x => x.HasParent == false);
        }

        public Node GetNodeByValue(int value)
        {
            return this.Nodes.FirstOrDefault(x => x.Value == value);
        }

        public IEnumerable<Node> GetAllLeaves()
        {
            return this.Nodes.Where(x => x.Children.Count < 1);
        }

        public IEnumerable<Node> GetAllMiddleNodes()
        {
            return this.Nodes.Where(x => x.HasParent && x.HasChildren);
        }

        public List<HashSet<int>> FindPaths(Node node, Stack<int> values, List<HashSet<int>> paths, bool isLastSibling = false)
        {
            values.Push(node.Value);
            
            if (!node.HasChildren)
            {
                paths.Add(new HashSet<int>(values));
                values.Pop();
                if (isLastSibling)
                {
                    values.Pop();
                    isLastSibling = false;
                }

            }
            else
            {
                for (int i = 0; i < node.Children.Count; i++)
                {
                    var child = node.Children[i];
                    if (node.HasParent)
                    {
                        if (i == node.Children.Count - 1)
                        {
                            isLastSibling = true;
                        }
                    }
                    
                    FindPaths(child, values, paths, isLastSibling);
                }
            }

            return paths;
        }

        public IEnumerable<HashSet<int>> FindPathsWithGivenSum(int sum)
        {
            var result = this.FindPaths(this.GetRootNode(), new Stack<int>(), new List<HashSet<int>>())
                             .Where(p => p.Sum() == sum);

            return result;
        }


    }
}
