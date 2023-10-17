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

public class PcBuilder : IPcBuilder
{
    private IMotherBoard? _motherBoard;
    private ICpu? _cpu;
    private ICoolingSystem? _coolingSystem;
    private IRam? _ram;
    private IVideoCard? _videoCard;
    private ISsd? _ssd;
    private IHdd? _hdd;
    private IPcCase? _pcCase;
    private IPsu? _psu;

    public IPcBuilder WithMotherBoard(IMotherBoard motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IPcBuilder WithCpu(ICpu cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IPcBuilder WithCoolingSystem(ICoolingSystem coolingSystem)
    {
        _coolingSystem = coolingSystem;
        return this;
    }

    public IPcBuilder WithRam(IRam ram)
    {
        _ram = ram;
        return this;
    }

    public IPcBuilder WithVideoCard(IVideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IPcBuilder WithSsd(ISsd? ssd)
    {
        _ssd = ssd;
        return this;
    }

    public IPcBuilder WithHdd(IHdd? hdd)
    {
        _hdd = hdd;
        return this;
    }

    public IPcBuilder WithPcCase(IPcCase pcCase)
    {
        _pcCase = pcCase;
        return this;
    }

    public IPcBuilder WithPsu(IPsu psu)
    {
        _psu = psu;
        return this;
    }

    public IPc Build()
    {
        throw new System.NotImplementedException();
    }
}