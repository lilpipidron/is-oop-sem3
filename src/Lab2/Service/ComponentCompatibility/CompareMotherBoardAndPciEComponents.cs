using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndPciEComponents<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IMotherboard
    where T2 : Collection<IPciEComponent?>
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        int lines = component1.PciE;
        if (component1.WiFiAdapter is not null)
        {
            lines--;
        }

        foreach (IPciEComponent? component in component2.Where(component => component is not null))
        {
            lines--;
        }

        if (lines < 0)
        {
            return new Result.Failed("Not enough PCIE lines");
        }

        return new Result.FullCompatible();
    }
}