using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class GenericTuple <T1, T2>
    {
        private Tuple<T1,T2> tuple;

        public GenericTuple(T1 firstElement, T2 secondElement)
        {
            tuple = new Tuple<T1, T2>(firstElement, secondElement);
        }

        public override string ToString()
        {
            return $"{tuple.Item1} -> {tuple.Item2}";
        }
    }
}
