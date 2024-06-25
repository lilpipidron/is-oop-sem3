namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCard : IBuilderDirector<IVideoCardBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption, IPciEComponent
{
    public int Height { get; }
    public int Width { get; }
    public int MemoryAmount { get; }
    public string VersionPciE { get; }
    public double ChipFrequency { get; }
}