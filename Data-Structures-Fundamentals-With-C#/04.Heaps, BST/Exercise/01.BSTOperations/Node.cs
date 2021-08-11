namespace _01.BSTOperations
{
    public class Node<T>
    {
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public int Count { get; set; }

        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
            Count = 1;
        }
    }
}
