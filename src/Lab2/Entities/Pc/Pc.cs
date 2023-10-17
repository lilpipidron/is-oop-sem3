using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;

public class Pc
{
    private readonly IMotherBoard _motherBoard;
    private readonly ICpu _cpu;
    private readonly ICoolingSystem _coolingSystem;
    private readonly IRam _ram;
    private readonly IVideoCard? _videoCard;
    private readonly ISsd? _ssd;
    private readonly IHdd? _hdd;
    private readonly IPcCase _pcCase;
    private readonly IPsu _psu;

    public Pc(
        IMotherBoard motherBoard,
        ICpu cpu,
        ICoolingSystem coolingSystem,
        IRam ram,
        IVideoCard? videoCard,
        ISsd? ssd,
        IHdd? hdd,
        IPcCase pcCase,
        IPsu psu)
    {
        _motherBoard = motherBoard;
        _cpu = cpu;
        _coolingSystem = coolingSystem;
        _ram = ram;
        _videoCard = videoCard;
        _ssd = ssd;
        _hdd = hdd;
        _pcCase = pcCase;
        _psu = psu;
    }

    public PcBuilder Director(PcBuilder builder)
    {
        builder
            .WithMotherBoard(_motherBoard)
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