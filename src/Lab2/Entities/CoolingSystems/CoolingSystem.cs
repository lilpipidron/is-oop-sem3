using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public class CoolingSystem : ICoolingSystem
{
    internal CoolingSystem(Dimension.HWDDimension dimension, IEnumerable<PcSocket> socket, int maxTdp)
    {
        Dimension = dimension;
        Socket = socket.ToArray();
        MaxTdp = maxTdp;
    }

    public Dimension.HWDDimension Dimension { get; }
    public IReadOnlyCollection<PcSocket> Socket { get; }
    public int MaxTdp { get; }

    public ICoolingSystemBuilder Director(ICoolingSystemBuilder builder)
    {
        builder
            .WithDimension(Dimension)
            .WithSocket(Socket)
            .WithMaxTdp(MaxTdp);

        return builder;
    }
}