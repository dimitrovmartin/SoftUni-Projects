namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> list;

        public MaxHeap()
        {
            this.list = new List<T>();
        }

        public int Size => list.Count;

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

        private void Swap(int childIndex, int parentIndex)
        {
            T temp = list[childIndex];

            list[childIndex] = list[parentIndex];
            list[parentIndex] = temp;
        }

        private bool IsGreater(int childIndex, int parentIndex)
        {
            return list[childIndex].CompareTo(list[parentIndex]) > 0;
        }
    }
}
