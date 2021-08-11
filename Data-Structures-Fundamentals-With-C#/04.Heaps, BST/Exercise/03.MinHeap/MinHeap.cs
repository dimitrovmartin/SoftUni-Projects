namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> priorityQueue;

        public MinHeap()
        {
            this.priorityQueue = new List<T>();
        }

        public int Size => priorityQueue.Count;

        public T Dequeue()
        {
            IsHeapEmpty();

            T temp = priorityQueue[0];

            priorityQueue[0] = priorityQueue[Size - 1];

            priorityQueue.RemoveAt(Size - 1);

            int parentIndex = 0;
            int childIndex = GetLeftChildIndex(parentIndex);

            HeapifyDown(parentIndex, childIndex);

            return temp;
        }

        private void HeapifyDown(int parentIndex, int childIndex)
        {
            int swapTo = childIndex;

            if (parentIndex != Size - 1 && swapTo >= Size)
            {
                return;
            }

            if (IsValidIndex(childIndex) && IsGreater(parentIndex, childIndex))
            {
                int rightChildIndex = GetRightChildIndex(parentIndex);

                if (IsValidIndex(rightChildIndex) && IsGreater(childIndex, rightChildIndex))
                {
                    swapTo = rightChildIndex;
                }

                Swap(parentIndex, swapTo);

                parentIndex = swapTo;
                swapTo = GetLeftChildIndex(parentIndex);

                HeapifyDown(parentIndex, swapTo);
            }
        }

        public void Add(T element)
        {
            priorityQueue.Add(element);

            int childIndex = Size - 1;
            int parentIndex = GetParentIndex(childIndex);

            HeapifyUp(childIndex, parentIndex);
        }

        public T Peek()
        {
            IsHeapEmpty();

            return priorityQueue[0];
        }

        private void IsHeapEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return (2 * parentIndex) + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return (2 * parentIndex) + 2;
        }

        private void HeapifyUp(int childIndex, int parentIndex)
        {
            if (childIndex == 0)
            {
                return;
            }

            if (IsLess(childIndex, parentIndex))
            {
                Swap(childIndex, parentIndex);

                childIndex = parentIndex;
                parentIndex = GetParentIndex(childIndex);

                HeapifyUp(childIndex, parentIndex);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T temp = priorityQueue[firstIndex];

            priorityQueue[firstIndex] = priorityQueue[secondIndex];
            priorityQueue[secondIndex] = temp;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return priorityQueue[childIndex].CompareTo(priorityQueue[parentIndex]) > 0;
        }

        private bool IsLess(int parentIndex, int childIndex)
        {
            return priorityQueue[parentIndex].CompareTo(priorityQueue[childIndex]) < 0;
        }

        private bool IsValidIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
