using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Chipsets;

public class Chipset
{
    public Chipset(IReadOnlyCollection<int> ramFrequency, bool supportXmp)
    {
        RamFrequency = ramFrequency;
        SupportXmp = supportXmp;
    }

    public bool SupportXmp { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
}