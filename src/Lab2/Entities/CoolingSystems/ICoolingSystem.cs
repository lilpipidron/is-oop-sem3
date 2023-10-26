using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public interface ICoolingSystem : IBuilderDirector<ICoolingSystemBuilder>, IPcComponent
{
    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
    public IReadOnlyCollection<PcSocket> Socket { get; }
    public int MaxTdp { get; }
}