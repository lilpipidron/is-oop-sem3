using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class Pc : IPc
{
    private readonly IMotherboard _motherboard;
    private readonly ICpu _cpu;
    private readonly ICoolingSystem _coolingSystem;
    private readonly IReadOnlyCollection<IRam> _ram;
    private readonly IVideoCard? _videoCard;
    private readonly ISsd? _ssd;
    private readonly IHdd? _hdd;
    private readonly IPcCase _pcCase;
    private readonly IPsu _psu;

    internal Pc(
        IMotherboard motherboard,
        ICpu cpu,
        ICoolingSystem coolingSystem,
        IReadOnlyCollection<IRam> ram,
        IVideoCard? videoCard,
        ISsd? ssd,
        IHdd? hdd,
        IPcCase pcCase,
        IPsu psu)
    {
        _motherboard = motherboard;
        _cpu = cpu;
        _coolingSystem = coolingSystem;
        _ram = ram;
        _videoCard = videoCard;
        _ssd = ssd;
        _hdd = hdd;
        _pcCase = pcCase;
        _psu = psu;
    }

    public IPcBuilder Director(IPcBuilder builder)
    {
        builder
            .WithMotherBoard(_motherboard)
            .WithCpu(_cpu)
            .WithCoolingSystem(_coolingSystem)
            .WithRam(_ram)
            .WithVideoCard(_videoCard)
            .WithSsd(_ssd)
            .WithHdd(_hdd)
            .WithPcCase(_pcCase)
            .WithPsu(_psu);

        return builder;
    }
}