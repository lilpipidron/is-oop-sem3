using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxVideoCardDimension(Dimension.HWDimension maxDimension);

    IPcCaseBuilder WithMotherBoardForms(IEnumerable<MotherBoardFormFactor> motherBoardForms);

    IPcCaseBuilder WithDimension(Dimension.HWDDimension dimension);

    IPcCase Build();
}