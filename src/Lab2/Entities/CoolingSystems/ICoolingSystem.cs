using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public interface ICoolingSystem : IBuilderDirector<ICoolingSystemBuilder>, IPcComponent
{
    public Dimension.CoolingDimension Dimension { get; }
    public IReadOnlyCollection<string> Socket { get; }
    public int MaxTdp { get; }
}