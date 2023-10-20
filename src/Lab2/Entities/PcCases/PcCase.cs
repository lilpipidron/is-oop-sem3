using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public class PcCase : IPcCase
{
    internal PcCase(
        Dimension.VideoCardDimension maxDimension,
        IEnumerable<MotherBoardFormFactor> motherBoardForms,
        Dimension.CaseDimension dimension)
    {
        MaxDimension = maxDimension;
        MotherBoardForms = motherBoardForms.ToArray();
        Dimension = dimension;
    }

    public Dimension.VideoCardDimension MaxDimension { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> MotherBoardForms { get; }
    public Dimension.CaseDimension Dimension { get; }

    public IPcCaseBuilder Director(IPcCaseBuilder builder)
    {
        builder
            .WithMaxVideoCardDimension(MaxDimension)
            .WithMotherBoardForms(MotherBoardForms)
            .WithDimension(Dimension);

        return builder;
    }
}