namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Ssds;

public interface ISsd : IBuilderDirector<ISsdBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption, IPciEComponent, ISataComponent
{
    public int MemoryAmount { get; }
    public int MaximumSpeed { get; }
    public string ConnectionOption { get; }
}