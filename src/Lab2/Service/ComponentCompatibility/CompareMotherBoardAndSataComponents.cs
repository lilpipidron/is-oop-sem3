using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndSataComponents : IComponentCompatibility
{
    private readonly IMotherboard _motherboard;
    private readonly IReadOnlyCollection<ISataComponent?> _components;

    public CompareMotherBoardAndSataComponents(IMotherboard motherboard, IReadOnlyCollection<ISataComponent?> components)
    {
        _motherboard = motherboard;
        _components = components;
    }

    public ComponentResult CheckCompability()
    {
        int lines = _motherboard.Sata;
        foreach (ISataComponent? sataComponent in _components.Where(sataComponent => sataComponent is not null))
        {
            lines--;
        }

        if (lines == _motherboard.Sata)
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