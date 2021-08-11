namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node(T value = default)
        {
            Value = value;
        }

        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}