using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithDimension(Dimension.CoolingDimension dimension);

    ICoolingSystemBuilder WithSocket(IEnumerable<string> socket);

    ICoolingSystemBuilder WithMaxTdp(int maxTdp);

    ICoolingSystem Build();
}