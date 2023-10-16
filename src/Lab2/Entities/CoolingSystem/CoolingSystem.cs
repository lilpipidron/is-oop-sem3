using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystem : ICoolingSystem
{
    private readonly ICoolingDimension _dimension;
    private readonly Collection<string> _socket;
    private readonly int _maxTdp;

    public CoolingSystem(int maxTdp, Collection<string> socket, ICoolingDimension dimension)
    {
        _maxTdp = maxTdp;
        _socket = socket;
        _dimension = dimension;
    }
}