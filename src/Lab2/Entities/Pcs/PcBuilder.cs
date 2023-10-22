using System.Collections.ObjectModel;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs

;

public class PcBuilder : IPcBuilder
{
    private IMotherboard? _motherBoard;
    private ICpu? _cpu;
    private ICoolingSystem? _coolingSystem;
    private Collection<IRam> _ram = new Collection<IRam>();
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

    public IPcBuilder WithRam(Collection<IRam> ram)
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
        Result res;
        if (_motherBoard is not null &&
            _cpu is not null &&
            _coolingSystem is not null &&
            _pcCase is not null &&
            _psu is not null)
        {
            var cal = new CompareAllComponents();
            res = CheckAllResults.CheckAllResult(cal.CompareAllComponent(
                _motherBoard,
                _cpu,
                _coolingSystem,
                _ram,
                _videoCard,
                _ssd,
                _hdd,
                _pcCase,
                _psu));
        }
        else
        {
            return new Result.Success(null, new Collection<string>());
        }

        if (res is Result.Success rs)
        {
            return new Result.Success(
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
                rs.Commentaries);
        }

        return res;
    }
}