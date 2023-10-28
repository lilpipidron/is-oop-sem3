using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndPciEComponents : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var components = pcComponents.Where(component => component is IPciEComponent) as IReadOnlyCollection<IPciEComponent?>;
        var motherboard = pcComponents.FirstOrDefault(component => component is IMotherboard) as IMotherboard;
        int? lines = motherboard?.PciE;
        if (motherboard?.WiFiAdapter is not null)
        {
            lines--;
        }

        if (components != null)
        {
            foreach (IPciEComponent? component in components.Where(component => component is not null))
            {
                lines--;
            }
        }

        if (lines < 0)
        {
            return new ComponentResult.Failed("Not enough PCIE lines");
        }

        return new ComponentResult.FullCompatible();
    }
}