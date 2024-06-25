using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;

public class CoolingSystemBuilder : ICoolingSystemBuilder
{
    private int? _height;
    private int? _width;
    private int? _depth;
    private IReadOnlyCollection<PcSocket>? _socket;
    private int? _maxTdp;

    public ICoolingSystemBuilder WithMaxTdp(int maxTdp)
    {
        _maxTdp = maxTdp;
        return this;
    }

    public ICoolingSystemBuilder WithSocket(IEnumerable<PcSocket> socket)
    {
        _socket = socket.ToArray();
        return this;
    }

    public ICoolingSystemBuilder WithDimension(int height, int width, int depth)
    {
        _height = height;
        _width = width;
        _depth = depth;
        return this;
    }

    public ICoolingSystem Build()
    {
        return new CoolingSystem(
            _height ?? throw new ArgumentNullException(nameof(_height)),
            _width ?? throw new ArgumentNullException(nameof(_width)),
            _depth ?? throw new ArgumentNullException(nameof(_depth)),
            _socket ?? throw new ArgumentNullException(nameof(_socket)),
            _maxTdp ?? throw new ArgumentNullException(nameof(_maxTdp)));
    }
}