using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;

public class Chipset : IChipset
{
    internal Chipset(IReadOnlyCollection<int> ramFrequency, Xmp? supportXmp)
    {
        RamFrequency = ramFrequency;
        SupportXmp = supportXmp;
    }

    public Xmp? SupportXmp { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }

    public IChipsetBuilder Director(IChipsetBuilder builder)
    {
        builder
            .WithRamFrequency(RamFrequency)
            .WithXmp(SupportXmp);

        return builder;
    }
}