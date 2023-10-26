using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndVideoCard : IComponentCompatibility
{
    private readonly IPcCase _pcCase;
    private readonly IVideoCard? _videoCard;

    public ComparePcCaseAndVideoCard(IPcCase pcCase, IVideoCard? videoCard)
    {
        _pcCase = pcCase;
        _videoCard = videoCard;
    }

    public ComponentResult CheckCompability()
    {
        if (_videoCard is null)
        {
            return new ComponentResult.FullCompatible();
        }

        if (_pcCase.MaxDimension.IsCompatible(_videoCard.Dimension) is false)
        {
            return new ComponentResult.Failed("The video card does not fit into the case");
        }

        return new ComponentResult.FullCompatible();
    }
}