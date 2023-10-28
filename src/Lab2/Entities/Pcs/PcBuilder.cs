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
    private IMotherboard? _motherBoard;
    private ICpu? _cpu;
    private ICoolingSystem? _coolingSystem;
    private IReadOnlyCollection<IRam>? _ram;
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

    public IPcBuilder WithRam(IReadOnlyCollection<IRam> ram)
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
            throw new ArgumentNullException($"Your PC doesn't have enough components");
        }

        IRamBuilder ramBuider = new RamBuilder();
        ramBuider = _ram.ElementAt(0).Director(ramBuider);
        IRam spcRam = ramBuider.WithPowerConsumption(_ram.Count * _ram.ElementAt(0).PowerConsumption).Build();
        IReadOnlyCollection<IComponentCompatibility> allCompare = new IComponentCompatibility[]
        {
            new CompareCpuAndRam(_cpu, _ram),
            new CompareMotherboardAndCpu(_motherBoard, _cpu),
            new CompareRamAndMotherboard(_ram, _motherBoard),
            new CompareCpuAndCoolingSystem(_cpu, _coolingSystem),
            new CompareCpuAndVideoCard(_cpu, _videoCard),
            new ComparePcCaseAndMotherboard(_pcCase, _motherBoard),
            new CompareMotherBoardAndSataComponents(_motherBoard, new ISataComponent?[] { _ssd, _hdd }),
            new ComparePcCaseAndCoolingSystem(_pcCase, _coolingSystem),
            new ComparePcCaseAndVideoCard(_pcCase, _videoCard),
            new ComparePsuAndFullPowerConsumption(_psu, new IPcComponentWithPowerConsumption?[] { _cpu, _videoCard, _ssd, _hdd, _motherBoard.WiFiAdapter, spcRam }),
            new CompareMotherBoardAndPciEComponents(_motherBoard, new IPciEComponent?[] { _videoCard, _ssd, _motherBoard.WiFiAdapter }),
        };
        var compareAllComponents = new CompareAllComponents(allCompare);
        IReadOnlyCollection<string?>? allComments = null;
        ComponentResult res = compareAllComponents.CompareAllComponent();

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
}