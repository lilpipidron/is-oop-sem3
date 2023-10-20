using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCard : IBuilderDirector<IVideoCardBuilder>, IPcComponent,
    IPcComponentWithPowerConsumption
{
    public Dimension.HWDimension Dimension { get; }
    public int MemoryAmount { get; }
    public string VersionPciE { get; }
    public double ChipFrequency { get; }
}