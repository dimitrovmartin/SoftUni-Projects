namespace List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IEnumerable<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] arr;

         public List(int capacity = DEFAULT_CAPACITY)
        {
            arr = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                IsValidIndex(index);

                return arr[index];
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
            ResizeIfNessecary();

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
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            IsValidIndex(index);
            ResizeIfNessecary();
            ShiftRight(index);

            arr[index] = item;

            Count++;
        }
        
        public bool Remove(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (arr[i].Equals(item))
                {
                    ShiftLeft(i);

                    Count--;

                    return true;
                }
            }

            return false;
        }
        
        public void RemoveAt(int index)
        {
            IsValidIndex(index);

            ShiftLeft(index);

            Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
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

        private void ResizeIfNessecary()
        {
            if (Count == arr.Length)
            {
                Resize();
            }
        }

        private void Resize()
        {
            T[] arrCopy = new T[arr.Length * 2];

            for (int i = 0; i < arr.Length; i++)
            {
                arrCopy[i] = arr[i];
            }

            arr = arrCopy;
        }
        
        private void ShiftRight(int index)
        {
            for (int i = Count; i >= index; i--)
            {
                arr[i] = arr[i - 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < Count; i++)
            {
                arr[i] = arr[i + 1];
            }
        }
    }
}
