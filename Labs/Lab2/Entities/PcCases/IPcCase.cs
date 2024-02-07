using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;

public interface IPcCase : IBuilderDirector<IPcCaseBuilder>, IPcComponent
{
    public int VideoCardHeight { get; }
    public int VideoCardWidth { get; }
    public IReadOnlyCollection<MotherBoardFormFactor> MotherBoardForms { get; }
    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
}