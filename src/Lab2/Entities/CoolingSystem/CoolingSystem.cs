using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystem : ICoolingSystem
{
    private readonly Dimension.CoolingDimension _dimension;
    private readonly IReadOnlyCollection<string> _socket;
    private readonly int _maxTdp;

    public CoolingSystem(Dimension.CoolingDimension dimension, IEnumerable<string> socket, int maxTdp)
    {
        _dimension = dimension;
        _socket = socket.ToArray();
        _maxTdp = maxTdp;
    }

    public ICoolingSystemBuilder Director(ICoolingSystemBuilder builder)
    {
        builder
            .WithDimension(_dimension)
            .WithSocket(_socket)
            .WithMaxTdp(_maxTdp);

        return builder;
    }
}