using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public interface ICoolingSystem : ICoolingSystemBuilderDirector, IHasName
{
    public Dimension.CoolingDimension Dimension { get; }
    public IReadOnlyCollection<string> Socket { get; }
    public int MaxTdp { get; }
}