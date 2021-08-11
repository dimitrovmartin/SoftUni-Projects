namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> head;

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

        public T Peek()
        {
            IsStackEmpty();

            return head.Value;
        }

        public T Pop()
        {
            IsStackEmpty();

            Node<T> oldHead = head;
            head = head.Next;

            Count--;

            return oldHead.Value;
        }

        
        public void Push(T item)
        {
            Node<T> newHead = new Node<T>(item);

            if (Count == 0)
            {
                head = newHead;
            }
            else
            {
                newHead.Next = head;
                head = newHead;
            }

            Count++;
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

        private void IsStackEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

    }
}