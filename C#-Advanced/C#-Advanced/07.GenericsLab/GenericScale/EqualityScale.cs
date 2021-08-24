using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IEquatable<T>
    {
        private T x;
        private T y;

        public EqualityScale(T x, T y)
        {
            this.x = x;
            this.y = y;
        }

      public bool AreEqual()
        {
            return x.Equals(y);
        }
    }
}
