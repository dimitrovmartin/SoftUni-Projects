using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IPrivate : ISoldier
    {
        decimal Salary { get; }
    }
}
