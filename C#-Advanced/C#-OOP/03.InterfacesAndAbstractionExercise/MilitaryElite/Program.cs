using MilitaryElite;
using MilitaryElite.Contracts;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;

namespace MillitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] soldierInfo = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = soldierInfo[0];
                string id = soldierInfo[1];
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    ISoldier @private = new Private(id, firstName, lastName, salary);

                    soldiers.Add(id, @private);
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < soldierInfo.Length; i++)
                    {
                        string privateId = soldierInfo[i];

                        if (soldiers.ContainsKey(privateId))
                        {
                            lieutenantGeneral.AddPrivate((IPrivate)soldiers[privateId]);
                        }
                    }

                    soldiers.Add(id, lieutenantGeneral);
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);

                    bool isValidCorps = Enum.TryParse(soldierInfo[5], out Corps corps);

                    if (isValidCorps)
                    {
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string partName = soldierInfo[i];
                            int hoursWorked = int.Parse(soldierInfo[i + 1]);

                            IRepair repair = new Repair(partName, hoursWorked);

                            engineer.AddRepair(repair);
                        }

                        soldiers.Add(id, engineer);
                    }
                    else
                    {
                        line = Console.ReadLine();
                        continue;
                    }
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    bool isValidCorps = Enum.TryParse(soldierInfo[5], out Corps corps);

                    if (isValidCorps)
                    {
                        Commando commando = new Commando(id, firstName, lastName, salary, corps);

                        for (int i = 6; i < soldierInfo.Length; i += 2)
                        {
                            string missionName = soldierInfo[i];
                            string state = soldierInfo[i + 1];
                            bool isMissionValid = Enum.TryParse(state, out State missionState);

                            if (isMissionValid)
                            {
                                Mission mission = new Mission(missionName, missionState);
                                commando.AddMission(mission);
                            }
                        }

                        soldiers.Add(id, commando);
                    }
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(soldierInfo[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(id, spy);
                }

                line = Console.ReadLine();
            }

            foreach (var soldier in soldiers.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
