using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
