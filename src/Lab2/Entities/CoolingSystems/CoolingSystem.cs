using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public class CoolingSystem : ICoolingSystem
{
    internal CoolingSystem(int height, int width, int depth, IEnumerable<PcSocket> socket, int maxTdp)
    {
        Height = height;
        Width = width;
        Depth = depth;
        Socket = socket.ToArray();
        MaxTdp = maxTdp;
    }

    public int Height { get; }
    public int Width { get; }
    public int Depth { get; }
    public IReadOnlyCollection<PcSocket> Socket { get; }
    public int MaxTdp { get; }

    public ICoolingSystemBuilder Director(ICoolingSystemBuilder builder)
    {
        builder
            .WithDimension(Height, Width, Depth)
            .WithSocket(Socket)
            .WithMaxTdp(MaxTdp);

        return builder;
    }
}