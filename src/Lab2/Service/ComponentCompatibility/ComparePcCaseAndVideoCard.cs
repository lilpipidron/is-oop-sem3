using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndVideoCard : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var pcCase = pcComponents.FirstOrDefault(component => component is IPcCase) as IPcCase;
        var videoCard = pcComponents.FirstOrDefault(component => component is IVideoCard) as IVideoCard;
        if (videoCard is null)
        {
            return new ComponentResult.FullCompatible();
        }

        if (pcCase?.VideoCardHeight < videoCard.Height || pcCase?.VideoCardWidth < videoCard.Width)
        {
            return new ComponentResult.Failed("The video card does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}