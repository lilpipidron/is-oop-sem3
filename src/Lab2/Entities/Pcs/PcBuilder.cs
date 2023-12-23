using System;
using System.Collections.Generic;
using System.Linq;
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
using Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public class PcBuilder : IPcBuilder
{
    private readonly IReadOnlyCollection<IComponentCompatibility> _componentCompatibilities;
    private IMotherboard? _motherBoard;
    private ICpu? _cpu;
    private ICoolingSystem? _coolingSystem;
    private IRam? _ram;
    private IVideoCard? _videoCard;
    private ISsd? _ssd;
    private IHdd? _hdd;
    private IPcCase? _pcCase;
    private IPsu? _psu;

    public PcBuilder(IEnumerable<IComponentCompatibility> componentCompatibilities)
    {
        _componentCompatibilities = componentCompatibilities.ToArray();
    }

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

    public PcResult Build()
    {
        if (_cpu is null || _motherBoard is null || _coolingSystem is null || _pcCase is null || _psu is null ||
            _ram is null)
        {
            throw new ArgumentNullException(null, $"Your PC doesn't have enough components");
        }

        var pcValidate = new PcValidationModel(
            _motherBoard,
            _cpu,
            _coolingSystem,
            _ram,
            _videoCard,
            _ssd,
            _hdd,
            _pcCase,
            _psu);
        var compareAllComponents = new CompareAllComponents(
            _componentCompatibilities, pcValidate);
        ComponentResult res = compareAllComponents.CompareAllComponent();
        IReadOnlyCollection<string?>? allComments = null;
        switch (res)
        {
            case ComponentResult.Failed rf:
                return new PcResult.Failed(rf.Reason);
            case ComponentResult.Compatible rc:
                allComments = rc.Commentaries;
                break;
        }

        return new PcResult.Success(
            new Pc(
                _motherBoard,
                _cpu,
                _coolingSystem,
                _ram,
                _videoCard,
                _ssd,
                _hdd,
                _pcCase,
                _psu),
            allComments);
    }

    public record PcValidationModel(
        IMotherboard Motherboard,
        ICpu Cpu,
        ICoolingSystem CoolingSystem,
        IRam Ram,
        IVideoCard? VideoCard,
        ISsd? Ssd,
        IHdd? Hdd,
        IPcCase PcCase,
        IPsu Psu);
}