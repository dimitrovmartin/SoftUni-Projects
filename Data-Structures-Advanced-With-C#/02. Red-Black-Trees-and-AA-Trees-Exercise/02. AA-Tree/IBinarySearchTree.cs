﻿namespace _02._AA_Tree
{
    using System;

    public interface IBinarySearchTree<T>
    {
        int CountNodes();

        bool IsEmpty();

        void Clear();

        void Insert(T element);

        bool Search(T element);

        void InOrder(Action<T> action);

        void PreOrder(Action<T> action);

        void PostOrder(Action<T> action);
    }
}
