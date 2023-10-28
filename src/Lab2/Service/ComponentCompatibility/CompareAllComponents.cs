using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareAllComponents
{
    private readonly IReadOnlyCollection<IComponentCompatibility> _compareFunc;
    private readonly IReadOnlyCollection<IPcComponent?> _pcComponents;

    public CompareAllComponents(IReadOnlyCollection<IComponentCompatibility> compareFunc, IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        _compareFunc = compareFunc;
        _pcComponents = pcComponents;
    }

    public ComponentResult CompareAllComponent()
    {
        List<string?> allMessages = new();
        foreach (IComponentCompatibility compare in _compareFunc)
        {
            ComponentResult res = compare.CheckCompability(_pcComponents);
            switch (res)
            {
                case ComponentResult.Failed:
                    return res;
                case ComponentResult.Compatible rc:
                    allMessages.Add(rc.Comment);
                    break;
            }
        }

        return new ComponentResult.Compatible(Commentaries: allMessages);
    }
}