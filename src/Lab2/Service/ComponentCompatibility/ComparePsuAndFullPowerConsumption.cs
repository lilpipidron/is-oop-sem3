using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePsuAndFullPowerConsumption : IComponentCompatibility
{
    private const double MaxEffectivePercent = 0.8;

    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        int allPowerConsumption = 0;
        var psu = pcComponents.FirstOrDefault(component => component is IPsu) as IPsu;
        foreach (IPcComponent? component in pcComponents)
        {
            if (component is IPcComponentWithPowerConsumption cps)
            {
                allPowerConsumption += cps.PowerConsumption;
            }
        }

        if (allPowerConsumption > psu?.PeakLoad * MaxEffectivePercent)
        {
            return new ComponentResult.Compatible("Failure to comply with recommended psu power delivery capacities");
        }

        return new ComponentResult.FullCompatible();
    }
}