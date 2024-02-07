using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;

public interface IChipset : IBuilderDirector<IChipsetBuilder>
{
    public Xmp? SupportXmp { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
}