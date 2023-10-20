using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxVideoCardDimension(Dimension.VideoCardDimension maxDimension);

    IPcCaseBuilder WithMotherBoardForms(IEnumerable<MotherBoardFormFactor> motherBoardForms);

    IPcCaseBuilder WithDimension(Dimension.CaseDimension dimension);

    IPcCase Build();
}