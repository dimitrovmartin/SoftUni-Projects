using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private Stack<T> stack;

        public CustomStack()
        {
            stack = new Stack<T>();
        }

        public void Push(T element)
        {
            stack.Push(element);
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
