using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;

public interface IChipsetBuilder
{
    IChipsetBuilder WithRamFrequency(IReadOnlyCollection<int> ramFrequency);

    IChipsetBuilder WithXmp(Xmp? xmp);

    IChipset Build();
}