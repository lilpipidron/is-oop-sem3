namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Hdds;

public interface IHdd : IBuilderDirector<IHddBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption, ISataComponent
{
    public int MemoryAmount { get; }
    public int SpindleSpeed { get; }
}