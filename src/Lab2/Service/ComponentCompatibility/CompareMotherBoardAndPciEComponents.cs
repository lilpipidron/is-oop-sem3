using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndPciEComponents : IComponentCompatibility
{
    private readonly IMotherboard _motherboard;
    private readonly IReadOnlyCollection<IPciEComponent?> _components;

    public CompareMotherBoardAndPciEComponents(IMotherboard motherboard, IReadOnlyCollection<IPciEComponent?> components)
    {
        _motherboard = motherboard;
        _components = components;
    }

    public ComponentResult CheckCompability()
    {
        int lines = _motherboard.PciE;
        if (_motherboard.WiFiAdapter is not null)
        {
            lines--;
        }

        foreach (IPciEComponent? component in _components.Where(component => component is not null))
        {
            lines--;
        }

        if (lines < 0)
        {
            return new ComponentResult.Failed("Not enough PCIE lines");
        }

        return new ComponentResult.FullCompatible();
    }
}