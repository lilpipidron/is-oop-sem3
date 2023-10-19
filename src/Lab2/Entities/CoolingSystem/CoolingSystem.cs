using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

internal class CoolingSystem : ICoolingSystem
{
    public CoolingSystem(string name, Dimension.CoolingDimension dimension, IEnumerable<string> socket, int maxTdp)
    {
        Name = name;
        Dimension = dimension;
        Socket = socket.ToArray();
        MaxTdp = maxTdp;
    }

    public string Name { get; }
    public Dimension.CoolingDimension Dimension { get; }
    public IReadOnlyCollection<string> Socket { get; }
    public int MaxTdp { get; }

    public ICoolingSystemBuilder Director(ICoolingSystemBuilder builder)
    {
        builder
            .WithName(Name)
            .WithDimension(Dimension)
            .WithSocket(Socket)
            .WithMaxTdp(MaxTdp);

        return builder;
    }
}