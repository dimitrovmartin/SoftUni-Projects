namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = this.Search(this.Root, item);
            return node != null;
        }

        public void Insert(T item)
        {
            this.Root = this.Insert(this.Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrder(this.Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = this.Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = this.Insert(node.Right, item);
            }

            node = UpdateBalance(node);

            UpdateHeight(node);

            return node;
        }

        private Node<T> UpdateBalance(Node<T> node)
        {
            int balance = Balance(node);

            if (balance > 1)
            {
                int childBalance = Balance(node.Left);

                if (childBalance < 0)
                {
                    node.Left = LLRotation(node.Left);
                }

                node = RRRotation(node);
            }
            else if (balance < -1)
            {
                int childBalance = Balance(node.Right);

                if (childBalance > 0)
                {
                    node.Right = RRRotation(node.Right);
                }

                node = LLRotation(node);
            }

            return node;
        }

        private Node<T> RRRotation(Node<T> node)
        {
            Node<T> left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> LLRotation(Node<T> node)
        {
            Node<T> right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }

        private int Balance(Node<T> node)
        {
            return Height(node.Left) - Height(node.Right);
        }

        private void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return node.Height;
            }
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Value);
            this.EachInOrder(node.Right, action);
        }
    }
}
