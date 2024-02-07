using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareAllComponents
{
    private readonly IReadOnlyCollection<IComponentCompatibility> _compareFunc;
    private readonly PcBuilder.PcValidationModel _validationModel;

    public CompareAllComponents(IReadOnlyCollection<IComponentCompatibility> compareFunc, PcBuilder.PcValidationModel validationModel)
    {
        _compareFunc = compareFunc;
        _validationModel = validationModel;
    }

    public ComponentResult CompareAllComponent()
    {
        List<string?> allMessages = new();
        foreach (IComponentCompatibility compare in _compareFunc)
        {
            ComponentResult res = compare.CheckCompability(_validationModel);
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