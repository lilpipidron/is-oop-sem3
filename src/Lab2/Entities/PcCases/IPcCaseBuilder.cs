using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCaseBuilder
{
    IPcCaseBuilder WithMaxVideoCardDimension(int videoCardHeight, int videoCardWidth);

    IPcCaseBuilder WithMotherBoardForms(IEnumerable<MotherBoardFormFactor> motherBoardForms);

    IPcCaseBuilder WithDimension(int height, int width, int depth);

    IPcCase Build();
}