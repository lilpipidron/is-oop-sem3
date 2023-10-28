using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndCoolingSystem : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var pcCase = pcComponents.FirstOrDefault(component => component is IPcCase) as IPcCase;
        var coolingSystem = pcComponents.FirstOrDefault(component => component is ICoolingSystem) as ICoolingSystem;
        if (
            pcCase?.Height < coolingSystem?.Height ||
            pcCase?.Width < coolingSystem?.Width ||
            pcCase?.Depth < coolingSystem?.Depth)
        {
            return new ComponentResult.Failed("Cooling System does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}