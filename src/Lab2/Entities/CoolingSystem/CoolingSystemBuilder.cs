using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private ICoolingDimension? _dimension;
    private IReadOnlyCollection<string>? _socket;
    private int? _maxTdp;

    public ICoolingSystemBuilder WithMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public ICoolingSystemBuilder WithSocket(IEnumerable<string> socket)
    {
        _socket = socket.ToArray();
        return this;
    }

    public ICoolingSystemBuilder WithDimension(ICoolingDimension dimension)
    {
        _dimension = dimension;
        return this;
    }

    public ICoolingSystem Build()
    {
        return new CoolingSystem(
            _dimension ?? throw new ArgumentNullException(nameof(_dimension)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _maxTdp ?? throw new ArgumentNullException(nameof(_maxTdp)));
    }
}