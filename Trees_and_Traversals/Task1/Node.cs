namespace Task1
{
    using System.Collections;
    using System.Collections.Generic;
    public class Node : IComparer
    {

        public Node(int value)
        {
            this.Value = value;
            this.Children = new List<Node>();
        }

        public int Value { get; set; }

        public List<Node> Children { get; set; }

        public bool HasParent { get; set; }

        public bool HasChildren 
        { 
            get { return this.Children.Count > 0; } 
        }

        public bool HasSiblings
        {
            get { return this.Parent.Children.Count > 1; }
        }

        public Node Parent { get; set; }

        public void AddChildren(params Node[] children)
        {
            for (int i = 0; i < children.Length; i++)
            {
                this.Children.Add(children[i]);
                children[i].HasParent = true;
                children[i].Parent = this;
            }
        }

        public override bool Equals(object obj)
        {
            return this.Value == (obj as Node).Value;
        }

        public int Compare(object x, object y)
        {
            return (x as Node).Value.CompareTo((y as Node).Value);
        }
    }
}
