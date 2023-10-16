using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;

public class PcCase : IPcCase
{
    private readonly IVideoCardDimension _maxDimension;
    private readonly Collection<MotherBoardFormFactor> _motherBoardForms;
    private readonly ICaseDimension _dimension;

    public PcCase(IVideoCardDimension maxDimension, Collection<MotherBoardFormFactor> motherBoardForms, ICaseDimension dimension)
    {
        _maxDimension = maxDimension;
        _motherBoardForms = motherBoardForms;
        _dimension = dimension;
    }
}