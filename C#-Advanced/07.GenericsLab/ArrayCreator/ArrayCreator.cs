using System;

namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T element)
        {
            T[] arr = new T[length];

            Array.Fill(arr, element);

            return arr;
        }
    }
}
