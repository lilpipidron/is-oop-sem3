using System.Collections.ObjectModel;
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
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;
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
        var coolingSystem = new CoolingSystem(1, 1, 1, new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(1, 1, 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(100, 100, new[] { new MotherBoardFormFactor.StandartAtx() }, 100, 100, 100);
        var psu = new Psu(1000);
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
        PcResult res = pcBuild.Build();
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
        var coolingSystem = new CoolingSystem(1, 1, 1, new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam> { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(1, 1, 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(100, 100, new[] { new MotherBoardFormFactor.StandartAtx() }, 100, 100, 100);
        var psu = new Psu(200);
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
        PcResult res = pcBuild.Build();
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
        var coolingSystem = new CoolingSystem(1, 1, 1, new[] { new PcSocket.AM2() }, 5);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(1, 1, 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(100, 100, new[] { new MotherBoardFormFactor.StandartAtx() }, 100, 100, 100);
        var psu = new Psu(1000);
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
        PcResult res = pcBuild.Build();
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
        var coolingSystem = new CoolingSystem(1, 1, 1, new[] { new PcSocket.AM2() }, 50);
        var ram = new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) };
        var videoCard = new VideoCard(1, 1, 5000, "1", 5, 20);
        var ssd = new Ssd(1, 11200, 100, "SATA");
        var hdd = new Hdd(1, 5600, 50);
        var pcCase = new PcCase(100, 100, new[] { new MotherBoardFormFactor.StandartAtx() }, 100, 100, 100);
        var psu = new Psu(1000);
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
        PcResult res = pcBuild.Build();
        Assert.StrictEqual(res, new PcResult.Failed("Sockets don't match"));
    }
}