using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareAllComponents
{
    private readonly IReadOnlyCollection<IComponentCompatibility> _compareFunc;

    public CompareAllComponents(IReadOnlyCollection<IComponentCompatibility> compareFunc)
    {
        _compareFunc = compareFunc;
    }

    public ComponentResult CompareAllComponent()
    {
        Collection<string?> allMessages = new();
        foreach (IComponentCompatibility compare in _compareFunc)
        {
            ComponentResult res = compare.CheckCompability();
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