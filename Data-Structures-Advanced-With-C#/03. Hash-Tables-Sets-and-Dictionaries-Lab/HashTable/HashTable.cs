namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private const double LoadFactor = 0.75;
        private const int DefaultCapacity = 4;

        private int maxElements;

        LinkedList<KeyValue<TKey, TValue>>[] hashTable;

        public HashTable(int capacity = DefaultCapacity)
        {
            hashTable = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public int Count { get; private set; }

        public int Capacity => hashTable.Length;

        public void Add(TKey key, TValue value)
        {
            CheckGrowth();

            int hash = Math.Abs(key.GetHashCode()) % Capacity;

            if (hashTable[hash] == null)
            {
                hashTable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            foreach (var kvp in hashTable[hash])
            {
                if (kvp.Key.Equals(key))
                {
                    throw new ArgumentException();
                }
            }

            hashTable[hash].AddLast(new KeyValue<TKey, TValue>(key, value));

            Count++;
        }

        private void CheckGrowth()
        {
            maxElements = (int)(Capacity * LoadFactor);

            if (Count == maxElements)
            {
                Grow();
            }
        }

        private void Grow()
        {
            HashTable<TKey, TValue> newTable = new HashTable<TKey, TValue>(Capacity * 2);

            foreach (var list in hashTable)
            {
                if (list != null)
                {
                    foreach (var kvp in list)
                    {
                        newTable.Add(kvp.Key, kvp.Value);
                    }
                }
            }

            hashTable = newTable.hashTable;
            Count = newTable.Count;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            CheckGrowth();

            int hash = Math.Abs(key.GetHashCode()) % Capacity;

            if (hashTable[hash] == null)
            {
                hashTable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }
            foreach (var kvp in hashTable[hash])
            {
                if (kvp.Key.Equals(key))
                {
                    kvp.Value = value;
                    return true;
                }
            }

            hashTable[hash].AddLast(new KeyValue<TKey, TValue>(key, value));

            Count++;

            return false;
        }

        public TValue Get(TKey key)
        {
            var kvp = Find(key);

            if (kvp == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return kvp.Value;
            }
            // Note: throw an exception on missing key
        }

        public TValue this[TKey key]
        {
            get => Get(key);

            set => AddOrReplace(key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var kvp = Find(key);

            if (kvp == null)
            {
                value = default(TValue);
                return false;
            }
            else
            {
                value = kvp.Value;
                return true;
            }
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode()) % Capacity;

            if (hashTable[hash] != null)
            {
                foreach (var kvp in hashTable[hash])
                {
                    if (key.Equals(kvp.Key))
                    {
                        return kvp;
                    }
                }
            }

            return null;
        }

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null;
        }

        public bool Remove(TKey key)
        {
            var kvp = Find(key);

            if (kvp == null)
            {
                return false;
            }
            else
            {
                int hash = Math.Abs(key.GetHashCode() % Capacity);

                hashTable[hash].Remove(kvp);

                Count--;

                return true;
            }
        }

        public void Clear()
        {
            hashTable = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            maxElements = (int)(Capacity * LoadFactor);

            Count = 0;
        }

        public IEnumerable<TKey> Keys => hashTable.Where(l => l != null).SelectMany(x => x.Select(y => y.Key));

        public IEnumerable<TValue> Values => hashTable.Where(l => l != null).SelectMany(x => x.Select(y => y.Value));

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var list in hashTable)
            {
                if (list != null)
                {
                    foreach (var kvp in list)
                    {
                        yield return kvp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
