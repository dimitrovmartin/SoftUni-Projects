using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        public void CompleteMission(IMission mission);
    }
}
