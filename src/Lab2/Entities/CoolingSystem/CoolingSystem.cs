using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystem : ICoolingSystem
{
    private readonly ICoolingDimension _dimension;
    private readonly IReadOnlyCollection<string> _socket;
    private readonly int _maxTdp;

    public CoolingSystem(int maxTdp, IEnumerable<string> socket, ICoolingDimension dimension)
    {
        _maxTdp = maxTdp;
        _socket = socket.ToArray();
        _dimension = dimension;
    }
}