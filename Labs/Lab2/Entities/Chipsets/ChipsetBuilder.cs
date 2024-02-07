using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Xmps;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;

public class ChipsetBuilder : IChipsetBuilder
{
    private IReadOnlyCollection<int> _ramFrequency = new List<int>();
    private Xmp? _xmp;

    public IChipsetBuilder WithRamFrequency(IReadOnlyCollection<int> ramFrequency)
    {
        _ramFrequency = ramFrequency;
        return this;
    }

    public IChipsetBuilder WithXmp(Xmp? xmp)
    {
        _xmp = xmp;
        return this;
    }

    public IChipset Build()
    {
        return new Chipset(
            _ramFrequency ?? throw new ArgumentNullException(nameof(_ramFrequency)),
            _xmp);
    }
}