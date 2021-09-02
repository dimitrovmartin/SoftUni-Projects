using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IBuyer
    {
        void BuyFood();

        int Food { get; }
    }
}
