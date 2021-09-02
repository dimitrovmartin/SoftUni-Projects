using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyList<IPrivate> Privates { get; }

        void AddPrivate(IPrivate @private);
    }
}
