namespace _01.Red_Black_Tree
{
    using System;
    using System.Collections.Generic;

    public class RedBlackTree<T>
        : IBinarySearchTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;

        private Node root;

        public RedBlackTree()
        {

        }

        public int Count => root?.Count ?? 0;

        public void Insert(T element)
        {
            root = Insert(root, element);
            root.Color = Black;
        }

        public T Select(int rank)
        {
            return Select(root, rank).Value;
        }

        public int Rank(T element)
        {
            return Rank(root, element);
        }

        public bool Contains(T element)
        {
            return Contains(root, element);
        }

        public IBinarySearchTree<T> Search(T element)
        {
            return null;
        }

        private bool Contains(Node node, T element)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Value.Equals(element))
            {
                return true;
            }
            else if (element.CompareTo(node.Value) < 0)
            {
                if (node.Left != null)
                {
                    return Contains(node.Left, element);
                }
            }
            else if (element.CompareTo(node.Value) > 0)
            {
                if (node.Right != null)
                {
                    return Contains(node.Right, element);
                }
            }

            return false;
        }

        public void DeleteMin()
        {
            root = DeleteMin(root);
            root.Color = Black;
        }

        public void DeleteMax()
        {
            root = DeleteMax(root);
            root.Color = Black;
        }

        public IEnumerable<T> Range(T startRange, T endRange)
        {
            return null;
        }

        public void Delete(T element)
        {
            root = Delete(root, element);
        }

        public T Ceiling(T element)
        {
            return Ceiling(root, element);
        }

        public T Floor(T element)
        {
            return Floor(root, element);
        }

        public void EachInOrder(Action<T> action)
        {
            DFS(root, action);
        }

        private Node Insert(Node node, T value)
        {
            if (node == null)
            {
                node = new Node(value);
            }

            if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(node.Left, value);
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                node.Right = Insert(node.Right, value);
            }

            node = Balance(node);

            return node;
        }

        private Node Balance(Node node)
        {
            if (IsRed(node.Right) && !IsRed(node.Left))
            {
                node = LeftRoration(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RightRotation(node);
            }

            if (IsRed(node.Right) && IsRed(node.Left))
            {
                FlipColors(node);
            }

            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);

            return node;
        }

        private void FlipColors(Node node)
        {
            node.Color = Red;
            node.Left.Color = Black;
            node.Right.Color = Black;
        }

        private Node LeftRoration(Node node)
        {
            Node temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return temp;
        }

        private Node RightRotation(Node node)
        {
            Node temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = node.Color;
            node.Color = Red;

            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return temp;
        }

        private bool IsRed(Node node)
        {
            if (node == null)
            {
                return false;
            }

            return true;
        }

        private int CountNodes(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return node.Right;
            }

            node.Left = DeleteMin(node.Left);
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private Node DeleteMax(Node node)
        {
            if (node.Right == null)
            {
                return node.Left;
            }

            node.Right = DeleteMax(node.Right);
            node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            return node;
        }

        private Node Delete(Node node, T element)
        {
            var comparer = element.CompareTo(node.Value);

            if (comparer < 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (comparer > 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }

                var replacement = Smallest(node.Left);

                node.Value = replacement.Value;
                node.Left = Delete(node.Left, replacement.Value);

                node.Count = 1 + CountNodes(node.Left) + CountNodes(node.Right);
            }

            node = Balance(node);
            return node;
        }

        private Node Smallest(Node node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Left != null)
            {
                return Smallest(node.Left);
            }
            else
            {
                return node;
            }
        }

        private void DFS(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            DFS(node.Left, action);
            action(node.Value);
            DFS(node.Right, action);
        }

        private T Floor(Node root, T key)
        {
            if (root == null)
            {
                return default(T);
            }

            if (root.Value.Equals(key))
            {
                return root.Value;
            }

            if (root.Value.CompareTo(key) > 0)
            {
                return Floor(root.Left, key);
            }

            T floorValue = Floor(root.Right, key);

            bool isValid = floorValue != null && floorValue.CompareTo(key) <= 0;

            return isValid ? floorValue : root.Value;
        }

        private T Ceiling(Node node, T value)
        {
            if (node == null)
            {
                return default(T);
            }

            if (node.Value.Equals(value))
            {
                return node.Value;
            }

            if (node.Value.CompareTo(value) < 0)
            {
                return Ceiling(node.Right, value);
            }

            T ceiling = Ceiling(node.Left, value);

            bool isValid = ceiling != null && ceiling.CompareTo(value) > 0;

            return isValid ? ceiling : node.Value; 
        }

        private int Rank(Node tree, T value)
        {
            int rank = 0;

            while (tree != null)
            {
                if (value.CompareTo(tree.Value) < 0)
                {
                    tree = tree.Left;
                }
                else if (value.CompareTo(tree.Value) > 0)
                {
                    rank += 1 + tree.Left.Count;
                    tree = tree.Right;
                }
                else
                {
                    return rank + tree.Left.Count;
                }
            }
            return rank;
        }

        private Node Select(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }

            int t = node.Left.Count;

            if (t > key)
            {
                return Select(node.Left, key);
            }
            else if (t < key)
            {
                return Select(node.Right, key - t - 1);
            }
            else
            {
                return node;
            }
        }


        private class Node
        {
            public Node(T value)
            {
                Value = value;
                Color = Red;
            }

            public T Value { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Count { get; set; }

            public bool Color { get; set; }
        }
    }
}