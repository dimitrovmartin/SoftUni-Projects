namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {

        public BinarySearchTree(Node<T> root = null)
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

        public bool Contains(T element)
        {
            if (Root == null)
            {
                return false;
            }

            Node<T> currentNode = Root;

            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(element) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(element) < 0)
                {
                    currentNode = currentNode.RightChild;
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
            Node<T> newNode = new Node<T>(element, null, null);

            if (Root == null)
            {
                Root = newNode;
                return;
            }
            else
            {
                InsertDfs(Root, element);
            }
        }

        private void InsertDfs(Node<T> node, T element)
        {
            Node<T> newNode = new Node<T>(element, null, null);

            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = newNode;
                    return;
                }

                InsertDfs(node.LeftChild, element);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = newNode;
                    return;
                }

                InsertDfs(node.RightChild, element);
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
             Node<T> currentNode = Root;

            while (currentNode != null && !currentNode.Value.Equals(element))
            {
                if (currentNode.Value.CompareTo(element) > 0)
                {
                    currentNode = currentNode.LeftChild;
                }
                else if (currentNode.Value.CompareTo(element) < 0)
                {
                    currentNode = currentNode.RightChild;
                }
            }

            return new BinarySearchTree<T>(currentNode);
        }
    }
}
