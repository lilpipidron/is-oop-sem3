using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;

public class PcCase : IPcCase
{
    private readonly Dimension.VideoCardDimension _maxDimension;
    private readonly IReadOnlyCollection<MotherBoardFormFactor> _motherBoardForms;
    private readonly Dimension.CaseDimension _dimension;

    public PcCase(
        Dimension.VideoCardDimension maxDimension,
        IEnumerable<MotherBoardFormFactor> motherBoardForms,
        Dimension.CaseDimension dimension)
    {
        _maxDimension = maxDimension;
        _motherBoardForms = motherBoardForms.ToArray();
        _dimension = dimension;
    }

    public IPcCaseBuilder Director(IPcCaseBuilder builder)
    {
        builder
            .WithMaxVideoCardDimension(_maxDimension)
            .WithMotherBoardForms(_motherBoardForms)
            .WithDimension(_dimension);

        return builder;
    }
}