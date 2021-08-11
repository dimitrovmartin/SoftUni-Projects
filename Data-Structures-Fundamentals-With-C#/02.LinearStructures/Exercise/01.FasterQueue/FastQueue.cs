namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            Node<T> currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            IsQueueEmpty();

            Node<T> oldHead = head;

            head = head.Next;

            Count--;

            return oldHead.Value;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }


        public T Peek()
        {
            IsQueueEmpty();

            return head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> currentNode = head;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void IsQueueEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}