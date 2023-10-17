using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;

public class Cpu : ICpu
{
    private readonly double _coreFrequency;
    private readonly double _coreAmount;
    private readonly string _socket;
    private readonly bool _videoCore;
    private readonly IReadOnlyCollection<int> _ramFrequency;
    private readonly int _tdp;
    private readonly int _powerConsumption;

    public Cpu(
        double coreFrequency,
        double coreAmount,
        string socket,
        bool videoCore,
        IEnumerable<int> ramFrequency,
        int tdp,
        int powerConsumption)
    {
        _coreFrequency = coreFrequency;
        _coreAmount = coreAmount;
        _socket = socket;
        _videoCore = videoCore;
        _ramFrequency = ramFrequency.ToArray();
        _tdp = tdp;
        _powerConsumption = powerConsumption;
    }
}