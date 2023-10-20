using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public class CoolingSystem : ICoolingSystem
{
    internal CoolingSystem(Dimension.CoolingDimension dimension, IEnumerable<string> socket, int maxTdp)
    {
        Dimension = dimension;
        Socket = socket.ToArray();
        MaxTdp = maxTdp;
    }

    public Dimension.CoolingDimension Dimension { get; }
    public IReadOnlyCollection<string> Socket { get; }
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