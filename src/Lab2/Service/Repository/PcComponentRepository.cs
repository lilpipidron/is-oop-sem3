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
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.RamFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.Repository;

public class PcComponentRepository : IRepository<IPcComponent>
{
    private readonly Collection<IPcComponent?> _entity = new();

    public PcComponentRepository()
    {
        _entity.Add(new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10));
        _entity.Add(new Motherboard(new PcSocket.AM2(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10) }), null));
        _entity.Add(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 50));
        _entity.Add(new Ram(2, new RamFormFactor.Dimm(), 4, 20, new Jedec("10-10-10-10", 20, 1600), null));
        _entity.Add(new VideoCard(new Dimension.HWDimension(1, 1), 5000, "1", 5, 20));
        _entity.Add(new Ssd(1, 11200, 100, "SATA"));
        _entity.Add(new Hdd(1, 5600, 50));
        _entity.Add(new PcCase(new Dimension.HWDimension(100, 100), new[] { new MotherBoardFormFactor.StandartAtx() }, new Dimension.HWDDimension(100, 100, 100)));
        _entity.Add(new Psu(1000));
        _entity.Add(new Psu(200));
        _entity.Add(new CoolingSystem(new Dimension.HWDDimension(1, 1, 1), new[] { new PcSocket.AM2() }, 5));
        _entity.Add(new Motherboard(new PcSocket.AM3(), 6, 6, new Chipset(new[] { 1600 }, null), 4, 4, new MotherBoardFormFactor.StandartAtx(), new Bios("Best", "Best", new[] { new Cpu(3, 5, new PcSocket.AM2(), new Ivc(20, 4000, 900), new[] { 1600 }, 30, 10) }), null));
    }

    public IReadOnlyCollection<IPcComponent?> GetAllComponents()
    {
        return _entity;
    }

    public void Add(IPcComponent? entity)
    {
        _entity.Add(entity);
    }

    public void Delete(IPcComponent? entity)
    {
        _entity.Remove(entity);
    }
}