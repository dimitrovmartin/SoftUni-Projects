using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private Stack<T> stack;

        public int Count => stack.Count;

        public Box()
        {
            stack = new Stack<T>();
        }

        public void Add(T element)
        {
            stack.Push(element);
        }

        public T Remove()
        {
            return stack.Pop();
        }
    }
}
