using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndCoolingSystem : IComponentCompatibility
{
    private readonly IPcCase _pcCase;
    private readonly ICoolingSystem _coolingSystem;

    public ComparePcCaseAndCoolingSystem(IPcCase pcCase, ICoolingSystem coolingSystem)
    {
        _pcCase = pcCase;
        _coolingSystem = coolingSystem;
    }

    public ComponentResult CheckCompability()
    {
        if (
            _pcCase.Height < _coolingSystem.Height ||
            _pcCase.Width < _coolingSystem.Width ||
            _pcCase.Depth < _coolingSystem.Depth)
        {
            return new ComponentResult.Failed("Cooling System does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}