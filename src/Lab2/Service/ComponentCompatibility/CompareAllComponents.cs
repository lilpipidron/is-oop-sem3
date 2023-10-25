using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
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

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareAllComponents
{
    private readonly List<Result> _allResults = new();

    public IEnumerable<Result> CompareAllComponent(
        IMotherboard motherboard,
        ICpu cpu,
        ICoolingSystem coolingSystem,
        Collection<IRam> ram,
        IVideoCard? videoCard,
        ISsd? ssd,
        IHdd? hdd,
        IPcCase pcCase,
        IPsu psu)
    {
        IRam fullRam = new Ram(ram[0].Amount, ram[0].RamFormFactor, ram[0].VersionDdr, ram[0].PowerConsumption * ram.Count, ram[0].JedecProfile, ram[0].XmpProfile);
        _allResults
            .AddRange(new Result[]
            {
                new CompareRamAndMotherboard<Collection<IRam>, IMotherboard>()
                    .CheckCompability(ram, motherboard),
                new ComparePcCaseAndVideoCard<IPcCase, IVideoCard>()
                    .CheckCompability(pcCase, videoCard),
                new ComparePcCaseAndMotherboard<IPcCase, IMotherboard>()
                    .CheckCompability(pcCase, motherboard),
                new ComparePcCaseAndCoolingSystem<IPcCase, ICoolingSystem>()
                    .CheckCompability(pcCase, coolingSystem),
                new CompareMotherboardAndCpu<IMotherboard, ICpu>()
                    .CheckCompability(motherboard, cpu),
                new CompareCpuAndVideoCard<ICpu, IVideoCard>()
                    .CheckCompability(cpu, videoCard),
                new CompareCpuAndRam<ICpu, Collection<IRam>>()
                    .CheckCompability(cpu, ram),
                new CompareCpuAndCoolingSystem<ICpu, ICoolingSystem>()
                    .CheckCompability(cpu, coolingSystem),
                new CompareMotherBoardAndSataComponents<IMotherboard, Collection<ISataComponent?>>()
                    .CheckCompability(motherboard, new Collection<ISataComponent?> { ssd, hdd }),
                new CompareMotherBoardAndPciEComponents<IMotherboard, Collection<IPciEComponent?>>()
                    .CheckCompability(motherboard, new Collection<IPciEComponent?> { videoCard, ssd }),
                new ComparePsuAndFullPowerConsumption<IPsu, Collection<IPcComponentWithPowerConsumption?>>()
                    .CheckCompability(psu, new Collection<IPcComponentWithPowerConsumption?>
                        { cpu, fullRam, videoCard, ssd, hdd, motherboard.WiFiAdapter }),
            });
        return _allResults;
    }
}