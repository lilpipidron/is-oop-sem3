using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Model.Chipsets;

public interface IChipset
{
    public bool SupportXmp { get; }
    public IReadOnlyCollection<int> RamFrequency { get; }
}