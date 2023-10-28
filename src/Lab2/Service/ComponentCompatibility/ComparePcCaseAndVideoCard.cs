using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndVideoCard : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.VideoCard is null)
        {
            return new ComponentResult.FullCompatible();
        }

        if (validationModel.PcCase.VideoCardHeight < validationModel.VideoCard.Height || validationModel.PcCase.VideoCardWidth < validationModel.VideoCard.Width)
        {
            return new ComponentResult.Failed("The video card does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}