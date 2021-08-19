namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            Copy(root);
        }

        private void Copy(Node<T> root)
        {
            if (root != null)
            {
                Insert(root.Value);
                Copy(root.LeftChild);
                Copy(root.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => Root.Count;

        public bool Contains(T element)
        {
            Node<T> current = Root;

            while (current != null)
            {
                if (IsGreater(current.Value, element))
                {
                    current = current.LeftChild;
                }
                else if (IsLess(current.Value, element))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            Node<T> toInsert = new Node<T>(element, null, null);

            if (Root == null)
            {
                Root = toInsert;
                return;
            }

            InsertDfs(Root, toInsert);
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            Node<T> current = Root;

            while (current != null)
            {

                if (IsGreater(current.Value, element))
                {
                    current = current.LeftChild;
                }
                else if (IsLess(current.Value, element))
                {
                    current = current.RightChild;
                }
                else
                {
                    return new BinarySearchTree<T>(current);
                }
            }

            return null;
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrderDfs(Root, action);
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                EachInOrderDfs(current.LeftChild, action);
                action(current.Value);
                EachInOrderDfs(current.RightChild, action);
            }
        }

        public List<T> Range(T lower, T upper)
        {
            return RangeBfs(lower, upper);
        }

        public void DeleteMin()
        {
            IsTreeEmpty();

            Node<T> current = Root;
            Node<T> previous = null;

            if (Root.LeftChild == null)
            {
                Root = Root.RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;

                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }
        }

        public void DeleteMax()
        {
            IsTreeEmpty();

            Node<T> current = Root;
            Node<T> previous = null;

            if (Root.RightChild == null)
            {
                Root = Root.LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;

                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;
            }
        }

        public int GetRank(T element)
        {
            return GetRankDfs(Root, element);
        }

        private int GetRankDfs(Node<T> current, T element)
        {
            if (current == null)
            {
                return 0;
            }

            if (IsGreater(current.Value,element))
            {
                return GetRankDfs(current.LeftChild, element);
            }
            else if (current.Value.Equals(element))
            {
                return current.Count;
            }

            return GetNodeCount(current.LeftChild) + 1
                + GetRankDfs(current.RightChild, element);
        }

        private int GetNodeCount(Node<T> current)
        {
            if (current == null)
            {
                return 0;
            }
            else
            {
                return current.Count;
            }
        }

        private bool IsGreater(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) > 0;
        }
        
        private bool IsLess(T firstValue, T secondValue)
        {
            return firstValue.CompareTo(secondValue) < 0;
        }

        private void IsTreeEmpty()
        {
            if (Root == null)
            {
                throw new InvalidOperationException();
            }
        }

        private List<T> RangeBfs(T lower, T upper)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            List<T> list = new List<T>();

            queue.Enqueue(Root);

            while (queue.Count != 0)
            {
                Node<T> currentNode = queue.Dequeue();

                if (IsGreater(currentNode.Value, lower) && IsLess(currentNode.Value, upper))
                {
                    list.Add(currentNode.Value);
                }
                else if (currentNode.Value.Equals(lower) || currentNode.Value.Equals(upper))
                {
                    list.Add(currentNode.Value);
                }

                if (currentNode.LeftChild != null)
                {
                    queue.Enqueue(currentNode.LeftChild);
                }

                if (currentNode.RightChild != null)
                {
                    queue.Enqueue(currentNode.RightChild);
                }
            }

            return list;
        }

        private void InsertDfs(Node<T> node, Node<T> toInsert)
        {
            if (IsGreater(node.Value, toInsert.Value))
            {
                node.Count++;

                if (node.LeftChild == null)
                {
                    node.LeftChild = toInsert;

                    if (LeftChild == null)
                    {
                        LeftChild = toInsert;
                    }

                    return;
                }
                else
                {
                    InsertDfs(node.LeftChild, toInsert);
                }
            }
            else if (IsLess(node.Value, toInsert.Value))
            {
                node.Count++;

                if (node.RightChild == null)
                {
                    node.RightChild = toInsert;

                    if (RightChild == null)
                    {
                        RightChild = toInsert;
                    }

                    return;
                }
                else
                {
                    InsertDfs(node.RightChild, toInsert);
                }
            }
        }
    }
}
