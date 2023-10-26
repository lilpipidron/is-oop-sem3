using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ivcs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Jedecs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;
using Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Test
{
    [Fact]
    public void FullSuccessBuild()
    {
        var pcBuild = new PcBuilder();
        var cpu = new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10);
        var motherboard = new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { cpu }), null);
        var coolingSystem = new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.StandartAtx() }, new Dimension.HWDDimension(100, 100, 100));
        var psu = new Psu(1000);
        IRamBuilder ramBuider = new RamBuilder();
        ramBuider = ram[0].Director(ramBuider);
        IRam spcRam = ramBuider.WithPowerConsumption(ram.Count * ram[0].PowerConsumption).Build();
        IReadOnlyCollection<IComponentCompatibility> allCompare = new IComponentCompatibility[]
        {
            new CompareCpuAndRam(cpu, ram),
            new CompareMotherboardAndCpu(motherboard, cpu),
            new CompareRamAndMotherboard(ram, motherboard),
            new CompareCpuAndCoolingSystem(cpu, coolingSystem),
            new CompareCpuAndVideoCard(cpu, videoCard),
            new ComparePcCaseAndMotherboard(pcCase, motherboard),
            new CompareMotherBoardAndSataComponents(motherboard, new ISataComponent?[] { ssd, hdd }),
            new ComparePcCaseAndCoolingSystem(pcCase, coolingSystem),
            new ComparePcCaseAndVideoCard(pcCase, videoCard),
            new ComparePsuAndFullPowerConsumption(psu, new IPcComponentWithPowerConsumption?[] { cpu, videoCard, ssd, hdd, motherboard.WiFiAdapter, spcRam }),
            new CompareMotherBoardAndPciEComponents(motherboard, new IPciEComponent?[] { videoCard, ssd, motherboard.WiFiAdapter }),
        };
        pcBuild
            .WithCpu(cpu)
            .WithMotherBoard(motherboard)
            .WithCoolingSystem(coolingSystem)
            .WithRam(ram)
            .WithVideoCard(videoCard)
            .WithSsd(ssd)
            .WithHdd(hdd)
            .WithPcCase(pcCase)
            .WithPsu(psu);
        PcResult res = pcBuild.Build(allCompare);
        if (res is PcResult.Success rs)
        {
            Assert.NotNull(rs.Pc);
            Assert.Equivalent(new Collection<string>(), rs.Commentaries);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void BuildWithWarning()
    {
        var pcBuild = new PcBuilder();
        var cpu = new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10);
        var motherboard = new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { cpu }), null);
        var coolingSystem = new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.StandartAtx() }, new Dimension.HWDDimension(100, 100, 100));
        var psu = new Psu(200);
        IRamBuilder ramBuider = new RamBuilder();
        ramBuider = ram[0].Director(ramBuider);
        IRam spcRam = ramBuider.WithPowerConsumption(ram.Count * ram[0].PowerConsumption).Build();
        IReadOnlyCollection<IComponentCompatibility> allCompare = new IComponentCompatibility[]
        {
            new CompareCpuAndRam(cpu, ram),
            new CompareMotherboardAndCpu(motherboard, cpu),
            new CompareRamAndMotherboard(ram, motherboard),
            new CompareCpuAndCoolingSystem(cpu, coolingSystem),
            new CompareCpuAndVideoCard(cpu, videoCard),
            new ComparePcCaseAndMotherboard(pcCase, motherboard),
            new CompareMotherBoardAndSataComponents(motherboard, new ISataComponent?[] { ssd, hdd }),
            new ComparePcCaseAndCoolingSystem(pcCase, coolingSystem),
            new ComparePcCaseAndVideoCard(pcCase, videoCard),
            new ComparePsuAndFullPowerConsumption(psu, new IPcComponentWithPowerConsumption?[] { cpu, videoCard, ssd, hdd, motherboard.WiFiAdapter, spcRam }),
            new CompareMotherBoardAndPciEComponents(motherboard, new IPciEComponent?[] { videoCard, ssd, motherboard.WiFiAdapter }),
        };
        pcBuild
            .WithCpu(cpu)
            .WithMotherBoard(motherboard)
            .WithCoolingSystem(coolingSystem)
            .WithRam(ram)
            .WithVideoCard(videoCard)
            .WithSsd(ssd)
            .WithHdd(hdd)
            .WithPcCase(pcCase)
            .WithPsu(psu);
        PcResult res = pcBuild.Build(allCompare);
        if (res is PcResult.Success rs)
        {
            Assert.NotNull(rs.Pc);
            Assert.Equivalent(new Collection<string> { "Failure to comply with recommended psu power delivery capacities" }, rs.Commentaries);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void BuildWithoutGuarantee()
    {
        var pcBuild = new PcBuilder();
        var cpu = new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10);
        var motherboard = new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { cpu }), null);
        var coolingSystem = new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 5);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.StandartAtx() }, new Dimension.HWDDimension(100, 100, 100));
        var psu = new Psu(1000);
        IRamBuilder ramBuider = new RamBuilder();
        ramBuider = ram[0].Director(ramBuider);
        IRam spcRam = ramBuider.WithPowerConsumption(ram.Count * ram[0].PowerConsumption).Build();
        IReadOnlyCollection<IComponentCompatibility> allCompare = new IComponentCompatibility[]
        {
            new CompareCpuAndRam(cpu, ram),
            new CompareMotherboardAndCpu(motherboard, cpu),
            new CompareRamAndMotherboard(ram, motherboard),
            new CompareCpuAndCoolingSystem(cpu, coolingSystem),
            new CompareCpuAndVideoCard(cpu, videoCard),
            new ComparePcCaseAndMotherboard(pcCase, motherboard),
            new CompareMotherBoardAndSataComponents(motherboard, new ISataComponent?[] { ssd, hdd }),
            new ComparePcCaseAndCoolingSystem(pcCase, coolingSystem),
            new ComparePcCaseAndVideoCard(pcCase, videoCard),
            new ComparePsuAndFullPowerConsumption(psu, new IPcComponentWithPowerConsumption?[] { cpu, videoCard, ssd, hdd, motherboard.WiFiAdapter, spcRam }),
            new CompareMotherBoardAndPciEComponents(motherboard, new IPciEComponent?[] { videoCard, ssd, motherboard.WiFiAdapter }),
        };
        pcBuild
            .WithCpu(cpu)
            .WithMotherBoard(motherboard)
            .WithCoolingSystem(coolingSystem)
            .WithRam(ram)
            .WithVideoCard(videoCard)
            .WithSsd(ssd)
            .WithHdd(hdd)
            .WithPcCase(pcCase)
            .WithPsu(psu);
        PcResult res = pcBuild.Build(allCompare);
        if (res is PcResult.Success rs)
        {
            Assert.NotNull(rs.Pc);
            Assert.Equivalent(new Collection<string> { "The store disclaims liability and warranty obligations" }, rs.Commentaries);
        }
        else
        {
            Assert.Fail();
        }
    }

    [Fact]
    public void FailedBuild()
    {
        var pcBuild = new PcBuilder();
        var cpu = new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10);
        var motherboard = new Motherboard(new PcSocket.AM3(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { cpu }), null);
        var coolingSystem = new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.StandartAtx() }, new Dimension.HWDDimension(100, 100, 100));
        var psu = new Psu(1000);
        IRamBuilder ramBuider = new RamBuilder();
        ramBuider = ram[0].Director(ramBuider);
        IRam spcRam = ramBuider.WithPowerConsumption(ram.Count * ram[0].PowerConsumption).Build();
        IReadOnlyCollection<IComponentCompatibility> allCompare = new IComponentCompatibility[]
        {
            new CompareCpuAndRam(cpu, ram),
            new CompareMotherboardAndCpu(motherboard, cpu),
            new CompareRamAndMotherboard(ram, motherboard),
            new CompareCpuAndCoolingSystem(cpu, coolingSystem),
            new CompareCpuAndVideoCard(cpu, videoCard),
            new ComparePcCaseAndMotherboard(pcCase, motherboard),
            new CompareMotherBoardAndSataComponents(motherboard, new ISataComponent?[] { ssd, hdd }),
            new ComparePcCaseAndCoolingSystem(pcCase, coolingSystem),
            new ComparePcCaseAndVideoCard(pcCase, videoCard),
            new ComparePsuAndFullPowerConsumption(psu, new IPcComponentWithPowerConsumption?[] { cpu, videoCard, ssd, hdd, motherboard.WiFiAdapter, spcRam }),
            new CompareMotherBoardAndPciEComponents(motherboard, new IPciEComponent?[] { videoCard, ssd, motherboard.WiFiAdapter }),
        };
        pcBuild
            .WithCpu(cpu)
            .WithMotherBoard(motherboard)
            .WithCoolingSystem(coolingSystem)
            .WithRam(ram)
            .WithVideoCard(videoCard)
            .WithSsd(ssd)
            .WithHdd(hdd)
            .WithPcCase(pcCase)
            .WithPsu(psu);
        PcResult res = pcBuild.Build(allCompare);
        Assert.StrictEqual(res, new PcResult.Failed("Sockets don't match"));
    }
}