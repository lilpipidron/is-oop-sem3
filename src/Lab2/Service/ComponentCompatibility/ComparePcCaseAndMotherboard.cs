using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndMotherboard<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : IPcCase
    where T2 : IMotherboard
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        if (component1.MotherBoardForms.FirstOrDefault(form => form == component2.MotherBoardFormFactor) is null)
        {
            return new Result.Failed("The case does not support this form factor");
        }

        return new Result.FullCompatible();
    }
}