namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Dictionary<T, Node<T>> nodesByValue;
        private Node<T> root;

        public Hierarchy(T value)
        {
            nodesByValue = new Dictionary<T, Node<T>>();
            root = new Node<T>(value);

            nodesByValue.Add(value, root);
        }

        public int Count => nodesByValue.Count;

        public void Add(T element, T child)
        {
            if (!nodesByValue.ContainsKey(element) || nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node<T> childNode = new Node<T>(child);
            Node<T> parentNode = nodesByValue[element];
            childNode.Parent = parentNode;

            parentNode.Children.Add(childNode);
            nodesByValue.Add(child, childNode);
        }

        public void Remove(T element)
        {
            if (root.Value.Equals(element))
            {
                throw new InvalidOperationException();
            }
            else if (!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }
            else
            {
                Node<T> nodeToRemove = nodesByValue[element];
                Node<T> parentNode = nodesByValue[nodeToRemove.Parent.Value];

                parentNode.Children.AddRange(nodeToRemove.Children);
                parentNode.Children.Remove(nodeToRemove);

                foreach (var child in nodeToRemove.Children)
                {
                    child.Parent = parentNode;
                }

                nodesByValue.Remove(nodeToRemove.Value);
            }
        }

        public IEnumerable<T> GetChildren(T element)
        {
            var parent = this.nodesByValue[element];

            return parent.Children.Select(x => x.Value);
        }

        public T GetParent(T element)
        {
            if (!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            Node<T> child = nodesByValue[element];

            if (child.Parent == null)
            {
                return default;
            }
            else
            {
                return child.Parent.Value;
            }
        }

        public bool Contains(T element)
        {
            return nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            List<T> currentValues = nodesByValue.Values.Select(x => x.Value).ToList();
            List<T> otherValues = other.nodesByValue.Values.Select(x => x.Value).ToList();

            return currentValues.Intersect(otherValues);
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                Node<T> node = queue.Dequeue();

                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}