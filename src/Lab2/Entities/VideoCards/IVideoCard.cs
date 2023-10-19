using Itmo.ObjectOrientedProgramming.Lab2.Model.Dimensions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;

public interface IVideoCard : IVideoCardBuilderDirector, IHasName
{
    public Dimension.VideoCardDimension Dimension { get; }
    public int MemoryAmount { get; }
    public string VersionPciE { get; }
    public double ChipFrequency { get; }
    public int PowerConsumption { get; }
}