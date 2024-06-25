using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public interface IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel);
}