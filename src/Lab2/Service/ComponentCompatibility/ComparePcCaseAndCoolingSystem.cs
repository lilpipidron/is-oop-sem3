using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndCoolingSystem : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (
            validationModel.PcCase.Height < validationModel.CoolingSystem.Height ||
            validationModel.PcCase.Width < validationModel.CoolingSystem.Width ||
            validationModel.PcCase.Depth < validationModel.CoolingSystem.Depth)
        {
            return new ComponentResult.Failed("Cooling System does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}