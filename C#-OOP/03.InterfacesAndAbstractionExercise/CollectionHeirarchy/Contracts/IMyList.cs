using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHeirarchy.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
       int Used { get; }
    }
}
