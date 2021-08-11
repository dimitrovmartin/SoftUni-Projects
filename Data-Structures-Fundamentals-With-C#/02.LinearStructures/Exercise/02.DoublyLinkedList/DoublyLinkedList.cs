namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = tail = newNode;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = newNode;
            }

            Count++;
        }

        public T GetFirst()
        {
            IsListEmpty();

            return head.Value;
        }
        

        public T GetLast()
        {
            IsListEmpty();

            return tail.Value;
        }

        public T RemoveFirst()
        {
            IsListEmpty();

            Node<T> oldHead = head;

            head = head.Next;
            Count--;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            IsListEmpty();

            Node<T> oldTail = tail;

            tail = tail.Previous;
            Count--;

            return oldTail.Value;
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

        private void IsListEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}