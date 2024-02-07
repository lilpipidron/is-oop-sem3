using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherBoardAndPciEComponents : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        int lines = validationModel.Motherboard.PciE;
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
            return new ComponentResult.Failed("Not enough PCIE lines");
        }

        return new ComponentResult.FullCompatible();
    }
}