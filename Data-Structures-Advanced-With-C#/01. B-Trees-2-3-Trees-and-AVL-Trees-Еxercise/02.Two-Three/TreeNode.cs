namespace _02.Two_Three
{
    using System;

    public class TreeNode<T> 
        where T : IComparable<T>
    {
        public T LeftKey;
        public T RightKey;

        public TreeNode<T> LeftChild;
        public TreeNode<T> MiddleChild;
        public TreeNode<T> RightChild;

        public TreeNode(T key)
        {
            this.LeftKey = key;
        }

        public bool IsThreeNode()
        {
            return RightKey != null;
        }

        public bool IsTwoNode()
        {
            return RightKey == null;
        }

        public bool IsLeaf()
        {
            return this.LeftChild == null && this.MiddleChild == null && this.RightChild == null;
        }
    }
}
