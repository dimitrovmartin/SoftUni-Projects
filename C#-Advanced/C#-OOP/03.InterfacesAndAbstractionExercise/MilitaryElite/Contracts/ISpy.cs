using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
