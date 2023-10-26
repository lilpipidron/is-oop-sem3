using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareRamAndMotherboard : IComponentCompatibility
{
    private readonly IEnumerable<IRam> _ram;
    private readonly IMotherboard _motherboard;

    public CompareRamAndMotherboard(IEnumerable<IRam> ram, IMotherboard motherboard)
    {
        _ram = ram;
        _motherboard = motherboard;
    }

    public ComponentResult CheckCompability()
    {
        if (_ram.Count() > _motherboard.RamCapacity)
        {
            return new ComponentResult.Failed("Too many Ram boards");
        }

        ComponentResult slower = new ComponentResult.FullCompatible();
        foreach (IRam ram in _ram)
        {
            if (ram.XmpProfile is not null && _motherboard.Chipset.SupportXmp is null)
            {
                return new ComponentResult.Failed("Motherboard doesn't support Xmp");
            }

            if (ram.VersionDdr != _motherboard.DdrStandard)
            {
                return new ComponentResult.Failed("Motherboard doesn't support this DDR version");
            }

            if (ram.XmpProfile is not null && _motherboard.Chipset.SupportXmp is not null)
            {
                if (ram.XmpProfile.Frequency > _motherboard.Chipset.SupportXmp.Frequency)
                {
                    slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
                }
            }

            if (_motherboard.Chipset.RamFrequency.FirstOrDefault(frequency => frequency >= ram.JedecProfile.Frequency) ==
                0)
            {
                slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
            }
        }

        return slower;
    }
}