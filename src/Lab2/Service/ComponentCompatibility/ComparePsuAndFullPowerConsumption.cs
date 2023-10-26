using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePsuAndFullPowerConsumption : IComponentCompatibility
{
    private const double MaxEffectivePercent = 0.8;
    private readonly IPsu _psu;
    private readonly IReadOnlyCollection<IPcComponentWithPowerConsumption?> _component;

    public ComparePsuAndFullPowerConsumption(IPsu psu, IReadOnlyCollection<IPcComponentWithPowerConsumption?> component)
    {
        _psu = psu;
        _component = component;
    }

    public ComponentResult CheckCompability()
    {
        int allPowerConsumption = 0;
        foreach (IPcComponentWithPowerConsumption? component in _component)
        {
            if (component is not null)
            {
                allPowerConsumption += component.PowerConsumption;
            }
        }

        if (allPowerConsumption > _psu.PeakLoad * MaxEffectivePercent)
        {
            return new ComponentResult.Compatible("Failure to comply with recommended psu power delivery capacities");
        }

        return new ComponentResult.FullCompatible();
    }
}