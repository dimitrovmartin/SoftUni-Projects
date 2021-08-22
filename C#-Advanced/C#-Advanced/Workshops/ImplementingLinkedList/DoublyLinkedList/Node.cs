namespace DoublyLinkedList
{
    public class Node<T>
    {
        public Node(T value = default)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }

        public Node<T> Previous { get; set; }
    }
}