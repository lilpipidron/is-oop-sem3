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

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;

public interface IPcBuilder
{
    IPcBuilder WithMotherBoard(IMotherboard motherboard);
    IPcBuilder WithCpu(ICpu cpu);
    IPcBuilder WithCoolingSystem(ICoolingSystem coolingSystem);
    IPcBuilder WithRam(IRam ram);
    IPcBuilder WithVideoCard(IVideoCard? videoCard);
    IPcBuilder WithSsd(ISsd? ssd);
    IPcBuilder WithHdd(IHdd? hdd);
    IPcBuilder WithPcCase(IPcCase pcCase);
    IPcBuilder WithPsu(IPsu psu);
    public PcResult Build();
}