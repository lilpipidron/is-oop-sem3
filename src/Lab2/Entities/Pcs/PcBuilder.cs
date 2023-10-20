using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs
;

public class PcBuilder : IPcBuilder
{
    private IMotherboard? _motherBoard;
    private ICpu? _cpu;
    private ICoolingSystem? _coolingSystem;
    private IRam? _ram;
    private IVideoCard? _videoCard;
    private ISsd? _ssd;
    private IHdd? _hdd;
    private IPcCase? _pcCase;
    private IPsu? _psu;

    public IPcBuilder WithMotherBoard(IMotherboard motherboard)
    {
        _motherBoard = motherboard;
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

    public Result Build()
    {
        throw new System.NotImplementedException();
    }
}