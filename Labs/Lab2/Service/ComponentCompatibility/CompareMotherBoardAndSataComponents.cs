using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndSataComponents : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        int lines = validationModel.Motherboard.Sata;

        if (validationModel.Ssd is not null)
        {
            lines--;
        }

        if (validationModel.VideoCard is not null)
        {
            lines--;
        }

        if (lines < 0)
        {
            return new ComponentResult.Failed("Not enough SATA lines");
        }

        return new ComponentResult.FullCompatible();
    }
}