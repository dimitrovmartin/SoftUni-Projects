using System.Collections.Generic;
using System.Linq;

namespace _01.Hierarchy
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public Node<T> Parent { get; set; }

        public List<Node<T>> Children { get; set; }
    }
}