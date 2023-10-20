using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public class PcCase : IPcCase
{
    internal PcCase(
        Dimension.HWDimension maxDimension,
        IEnumerable<MotherBoardFormFactor> motherBoardForms,
        Dimension.HWDDimension dimension)
    {
        MaxDimension = maxDimension;
        MotherBoardForms = motherBoardForms.ToArray();
        Dimension = dimension;
    }

    public Dimension.HWDimension MaxDimension { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> MotherBoardForms { get; }
    public Dimension.HWDDimension Dimension { get; }

    public IPcCaseBuilder Director(IPcCaseBuilder builder)
    {
        builder
            .WithMaxVideoCardDimension(MaxDimension)
            .WithMotherBoardForms(MotherBoardForms)
            .WithDimension(Dimension);

        return builder;
    }
}