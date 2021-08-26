namespace _03.AVL
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

        public void Delete(T v)
        {
            if (Contains(v))
            {
                this.Root = Delete(this.Root, v);
            }
        }

        public void DeleteMin()
        {
            if (this.Root != null)
            {
                var smallest = Smallest(this.Root);
                Delete(smallest.Value);
            }
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

            node = Balance(node);
            UpdateHeight(node);
            return node;
        }

        private Node<T> Balance(Node<T> node)
        {
            var balance = Height(node.Left) - Height(node.Right);
            if (balance > 1)
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                node = RotateRight(node);
            }
            else if (balance < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                node = RotateLeft(node);
            }

            return node;
        }

        private void UpdateHeight(Node<T> node)
        {
            if (node != null)
            {
                node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
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

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);

            return left;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);

            return right;
        }

        private Node<T> Smallest(Node<T> node)
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

        private Node<T> Greatest(Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Right != null)
            {
                return Greatest(node.Right);
            }
            else
            {
                return node;
            }
        }

        private Node<T> Delete(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);

            if (cmp < 0)
            {
                node.Left = Delete(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = Delete(node.Right, item);
            }

            if (cmp == 0)
            {
                // When node has no children
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                //When node has only left child
                if (node.Left != null && node.Right == null)
                {
                    return node.Left;
                }
                //When node has only right child
                if (node.Left == null && node.Right != null)
                {
                    return node.Right;
                }

                if (node.Left.Height > node.Right.Height)
                {
                    Node<T> replacement = Greatest(node.Left);
                    node.Value = replacement.Value;
                    node.Left = Delete(node.Left, replacement.Value);

                    UpdateHeight(node.Left);
                    UpdateHeight(node);
                }
                else
                {
                    Node<T> replacement = Smallest(node.Right);
                    node.Value = replacement.Value;
                    node.Right = Delete(node.Right, replacement.Value);

                    UpdateHeight(node.Right);
                    UpdateHeight(node);
                }
            }

            node = Balance(node);
            UpdateHeight(node);

            return node;
        }
    }
}