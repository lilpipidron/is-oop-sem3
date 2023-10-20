using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCase : IBuilderDirector<IPcCaseBuilder>, IPcComponent
{
    public Dimension.HWDimension MaxDimension { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> MotherBoardForms { get; }
    public Dimension.HWDDimension Dimension { get; }
}