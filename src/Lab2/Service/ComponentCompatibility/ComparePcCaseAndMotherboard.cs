using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndMotherboard : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var pcCase = pcComponents.FirstOrDefault(component => component is IPcCase) as IPcCase;
        var motherboard = pcComponents.FirstOrDefault(component => component is IMotherboard) as IMotherboard;
        if (pcCase?.MotherBoardForms.FirstOrDefault(form => form == motherboard?.MotherBoardFormFactor) is null)
        {
            return new ComponentResult.Failed("The case does not support this form factor");
        }

        return new ComponentResult.FullCompatible();
    }
}