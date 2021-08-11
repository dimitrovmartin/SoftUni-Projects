namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] arr;

        public ReversedList(int capacity = DefaultCapacity)
        {
            this.arr = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                IsValidIndex(Count - index - 1);

                return arr[Count - index - 1];
            }
            set
            {
                IsValidIndex(index);

                arr[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            IsResizeNessesary();

            arr[Count] = item;

            Count++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(item))
                {
                    return Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            IsValidIndex(index);
            IsResizeNessesary();
            ShiftRight(index);

            arr[Count - index] = item;
            Count++;
        }

        private void ShiftRight(int index)
        {
            for (int i = Count; i > Count - index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);

            if (itemIndex == -1)
            {
                return false;
            }
            else
            {
                RemoveAt(itemIndex);

                return true;
            }
        }

        public void RemoveAt(int index)
        {
            IsValidIndex(index);

            ShiftLeft(index);

            Count--;
        }

        private void ShiftLeft(int index)
        {
            for (int i = Count - index - 1; i < Count; i++)
            {
                arr[i] = arr[i + 1];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void IsValidIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        private void IsResizeNessesary()
        {
            if (Count == arr.Length)
            {
                Resize();
            }
        }

        private void Resize()
        {
            T[] copyArr = new T[arr.Length * 2];

            for (int i = 0; i < arr.Length; i++)
            {
                copyArr[i] = arr[i];
            }

            arr = copyArr;
        }
    }
}