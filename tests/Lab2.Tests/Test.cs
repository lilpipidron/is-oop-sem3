using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystems;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;
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
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Test
{
    [Fact]
    public void FullSuccessBuild()
    {
        var pcBuild = new PcBuilder();
        pcBuild.WithCpu(new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10));
        pcBuild.WithMotherBoard(new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.MiniMotherBoardForm(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10) }), null));
        pcBuild.WithCoolingSystem(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50));
        pcBuild.WithRam(new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) });
        pcBuild.WithVideoCard(new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20));
        pcBuild.WithSsd(new Ssd(1, 11200, 100, "SATA"));
        pcBuild.WithHdd(new Hdd(1, 5600, 50));
        pcBuild.WithPcCase(new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.MiniMotherBoardForm() },  new Dimension.HWDDimension(100, 100, 100)));
        pcBuild.WithPsu(new Psu(1000));
        Result res = pcBuild.Build();
        Assert.True(res is Result.Success);
    }

    [Fact]
    public void BuildWithWarning()
    {
        var pcBuild = new PcBuilder();
        pcBuild.WithCpu(new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10));
        pcBuild.WithMotherBoard(new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.MiniMotherBoardForm(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10) }), null));
        pcBuild.WithCoolingSystem(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50));
        pcBuild.WithRam(new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) });
        pcBuild.WithVideoCard(new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20));
        pcBuild.WithSsd(new Ssd(1, 11200, 100, "SATA"));
        pcBuild.WithHdd(new Hdd(1, 5600, 50));
        pcBuild.WithPcCase(new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.MiniMotherBoardForm() },  new Dimension.HWDDimension(100, 100, 100)));
        pcBuild.WithPsu(new Psu(200));
        Result res = pcBuild.Build();
        Assert.True(res is Result.Success);
    }

    [Fact]
    public void BuildWithoutGuarantee()
    {
        var pcBuild = new PcBuilder();
        pcBuild.WithCpu(new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10));
        pcBuild.WithMotherBoard(new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.MiniMotherBoardForm(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10) }), null));
        pcBuild.WithCoolingSystem(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 5));
        pcBuild.WithRam(new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) });
        pcBuild.WithVideoCard(new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20));
        pcBuild.WithSsd(new Ssd(1, 11200, 100, "SATA"));
        pcBuild.WithHdd(new Hdd(1, 5600, 50));
        pcBuild.WithPcCase(new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.MiniMotherBoardForm() },  new Dimension.HWDDimension(100, 100, 100)));
        pcBuild.WithPsu(new Psu(2000));
        Result res = pcBuild.Build();
        Assert.True(res is Result.Success);
    }

    [Fact]
    public void FailedBuild()
    {
        var pcBuild = new PcBuilder();
        pcBuild.WithCpu(new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10));
        pcBuild.WithMotherBoard(new Motherboard(new PcSocket.AM3(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.MiniMotherBoardForm(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), true, new[] { 1600 }, 30, 10) }), null));
        pcBuild.WithCoolingSystem(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50));
        pcBuild.WithRam(new Collection<IRam>() { new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null) });
        pcBuild.WithVideoCard(new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20));
        pcBuild.WithSsd(new Ssd(1, 11200, 100, "SATA"));
        pcBuild.WithHdd(new Hdd(1, 5600, 50));
        pcBuild.WithPcCase(new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.MiniMotherBoardForm() },  new Dimension.HWDDimension(100, 100, 100)));
        pcBuild.WithPsu(new Psu(200));
        Result res = pcBuild.Build();
        Assert.True(res is Result.Failed);
    }
}