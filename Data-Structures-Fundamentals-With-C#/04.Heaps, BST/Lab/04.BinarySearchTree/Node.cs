namespace _04.BinarySearchTree
{
    public class Node<T>
    {
        public Node(T value, Node<T> leftChild, Node<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }
    }
}
