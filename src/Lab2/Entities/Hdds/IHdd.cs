namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHdd : IBuilderDirector<IHddBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
}