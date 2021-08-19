namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            DfsStringAsIndentedPreOrder(this, sb, indent);

            return sb.ToString();
        }
        
        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            DfsInOrder(this, list);

            return list;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            DfsPostOrder(this, list);

            return list;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            return DfsPreOrder(this);
        }

        public void ForEachInOrder(Action<T> action)
        {
            DfsForeachInOrder(this, action);
        }

        private void DfsForeachInOrder(IAbstractBinaryTree<T> binaryTree, Action<T> action)
        {
            if (binaryTree.LeftChild != null)
            {
                DfsForeachInOrder(binaryTree.LeftChild, action);
            }

            action.Invoke(binaryTree.Value);

            if (binaryTree.RightChild != null)
            {
                DfsForeachInOrder(binaryTree.RightChild, action);
            }
        }

        private void DfsStringAsIndentedPreOrder(IAbstractBinaryTree<T> binaryTree, StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + binaryTree.Value);

            if (binaryTree.LeftChild != null)
            {
                DfsStringAsIndentedPreOrder(binaryTree.LeftChild, sb, indent + 2);
            }

            if (binaryTree.RightChild != null)
            {
                DfsStringAsIndentedPreOrder(binaryTree.RightChild, sb, indent + 2);
            }
        }

        private void DfsInOrder(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> list)
        {
            if (binaryTree.LeftChild != null)
            {
                DfsInOrder(binaryTree.LeftChild, list);
            }

            list.Add(binaryTree);

            if (binaryTree.RightChild != null)
            {
                DfsInOrder(binaryTree.RightChild, list);
            }
        }

        private void DfsPostOrder(IAbstractBinaryTree<T> binaryTree, List<IAbstractBinaryTree<T>> list)
        {
            if (binaryTree.LeftChild != null)
            {
                DfsPostOrder(binaryTree.LeftChild, list);
            }

            if (binaryTree.RightChild != null)
            {
                DfsPostOrder(binaryTree.RightChild, list);
            }

            list.Add(binaryTree);
        }

        private List<IAbstractBinaryTree<T>> DfsPreOrder(IAbstractBinaryTree<T> binaryTree)
        {
            List<IAbstractBinaryTree<T>> list = new List<IAbstractBinaryTree<T>>();

            list.Add(binaryTree);

            if (binaryTree.LeftChild != null)
            {
                list.AddRange(DfsPreOrder(binaryTree.LeftChild));
            }

            if (binaryTree.RightChild != null)
            {
                list.AddRange(DfsPreOrder(binaryTree.RightChild));
            }

            return list;
        }
    }
}
