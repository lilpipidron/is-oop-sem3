using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndSataComponents : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var pcCase = pcComponents.FirstOrDefault(component => component is IPcCase) as IPcCase;
        var motherboard = pcComponents.FirstOrDefault(component => component is IMotherboard) as IMotherboard;
        int? lines = motherboard?.Sata;

        lines -= pcComponents.Count(component => component is ISataComponent);

        if (lines == motherboard?.Sata)
        {
            return new ComponentResult.Failed("There are no memory drives in this build.");
        }

        if (lines < 0)
        {
            return new ComponentResult.Failed("Not enough SATA lines");
        }

        return new ComponentResult.FullCompatible();
    }
}