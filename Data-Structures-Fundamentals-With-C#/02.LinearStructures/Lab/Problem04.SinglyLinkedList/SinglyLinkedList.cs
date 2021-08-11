namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
            }
            else
            {
                newNode.Next = head;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            Node<T> newNode = new Node<T>(item);

            if (Count == 0)
            {
                head = newNode;
            }
            else
            {
                Node<T> currentNode = head;

                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
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

            Node<T> currentNode = head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
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

            Node<T> currentNode = head;
            Node<T> secondCurrentNode = head;

            while (currentNode.Next != null)
            {
                secondCurrentNode = currentNode;
                currentNode = currentNode.Next;
            }

            Node<T> nodeToReturn = currentNode;

            secondCurrentNode.Next = null;
            currentNode = null;

            Count--;

            return nodeToReturn.Value;
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

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void IsListEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}