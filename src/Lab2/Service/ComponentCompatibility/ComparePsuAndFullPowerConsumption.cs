using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePsuAndFullPowerConsumption<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IPsu
    where T2 : Collection<IPcComponentWithPowerConsumption?>
{
    private const double MaxEffectivePercent = 0.8;

    public Result CheckCompability(T1 component1, T2 component2)
    {
        int allPowerConsumption = 0;
        foreach (IPcComponentWithPowerConsumption? component in component2)
        {
            if (component is not null)
            {
                allPowerConsumption += component.PowerConsumption;
            }
        }

        if (allPowerConsumption > component1.PeakLoad * MaxEffectivePercent)
        {
            return new Result.Compatible("Failure to comply with recommended psu power delivery capacities");
        }

        return new Result.FullCompatible();
    }
}