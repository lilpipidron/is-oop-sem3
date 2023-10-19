using Itmo.ObjectOrientedProgramming.Lab2.Entities.CoolingSystem;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCase;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Psu;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ram;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssd;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCard;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc;

public interface IPcBuilder
{
    IPcBuilder WithMotherBoard(IMotherBoard motherBoard);
    IPcBuilder WithCpu(ICpu cpu);
    IPcBuilder WithCoolingSystem(ICoolingSystem coolingSystem);
    IPcBuilder WithRam(IRam ram);
    IPcBuilder WithVideoCard(IVideoCard? videoCard);
    IPcBuilder WithSsd(ISsd? ssd);
    IPcBuilder WithHdd(IHdd? hdd);
    IPcBuilder WithPcCase(IPcCase pcCase);
    IPcBuilder WithPsu(IPsu psu);
    Result Build();
}