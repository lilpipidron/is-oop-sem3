using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndSataComponents<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IMotherboard
    where T2 : Collection<ISataComponent?>
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        int lines = component1.Sata;
        foreach (ISataComponent? sataComponent in component2.Where(sataComponent => sataComponent is not null))
        {
            lines--;
        }

        if (lines == component1.Sata)
        {
            return new Result.Failed("There are no memory drives in this build.");
        }

        if (lines < 0)
        {
            return new Result.Failed("Not enough SATA lines");
        }

        return new Result.FullCompatible();
    }
}