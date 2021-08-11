namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public PriorityQueue()
        {
            this.list = new List<T>();
        }

        public int Size => list.Count;

        public T Dequeue()
        {
            IsHeapEmpty();

            T temp = list[0];

            list[0] = list[Size - 1];

            list.RemoveAt(Size - 1);

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

            if (IsValidIndex(childIndex) && IsLess(parentIndex, childIndex))
            {
                int rightChildIndex = GetRightChildIndex(parentIndex);

                if (IsValidIndex(rightChildIndex) && IsLess(childIndex, rightChildIndex))
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
            list.Add(element);

            int childIndex = Size - 1;
            int parentIndex = GetParentIndex(childIndex);

            HeapifyUp(childIndex, parentIndex);
        }

        public T Peek()
        {
            IsHeapEmpty();

            return list[0];
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

            if (IsGreater(childIndex, parentIndex))
            {
                Swap(childIndex, parentIndex);

                childIndex = parentIndex;
                parentIndex = GetParentIndex(childIndex);

                HeapifyUp(childIndex, parentIndex);
            }
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            T temp = list[firstIndex];

            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return list[childIndex].CompareTo(list[parentIndex]) > 0;
        }

        private bool IsLess(int parentIndex, int childIndex)
        {
            return list[parentIndex].CompareTo(list[childIndex]) < 0;
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
