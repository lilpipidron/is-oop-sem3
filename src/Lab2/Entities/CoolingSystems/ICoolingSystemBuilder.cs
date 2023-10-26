using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public interface ICoolingSystemBuilder
{
    ICoolingSystemBuilder WithDimension(int height, int width, int depth);

    ICoolingSystemBuilder WithSocket(IEnumerable<PcSocket> socket);

    ICoolingSystemBuilder WithMaxTdp(int maxTdp);

    ICoolingSystem Build();
}