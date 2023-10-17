using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxVideoCardDimension(IVideoCardDimension maxDimension);

    IPcCaseBuilder WithMotherBoardForms(IEnumerable<MotherBoardFormFactor> motherBoardForms);

    IPcCaseBuilder WithDimension(ICaseDimension dimension);

    IPcCase Build();
}