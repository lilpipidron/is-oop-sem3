using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareRamAndMotherboard : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var ram = pcComponents.FirstOrDefault(component => component is IRam) as IRam;
        var motherboard = pcComponents.FirstOrDefault(component => component is IMotherboard) as IMotherboard;
        if (ram?.AmountBoards > motherboard?.RamCapacity)
        {
            return new ComponentResult.Failed("Too many Ram boards");
        }

        ComponentResult slower = new ComponentResult.FullCompatible();
        if (ram?.XmpProfile is not null && motherboard?.Chipset.SupportXmp is null)
        {
            return new ComponentResult.Failed("Motherboard doesn't support Xmp");
        }

        if (ram?.VersionDdr != motherboard?.DdrStandard)
        {
            return new ComponentResult.Failed("Motherboard doesn't support this DDR version");
        }

        if (ram?.XmpProfile is not null && motherboard?.Chipset.SupportXmp is not null)
        {
            if (ram.XmpProfile.Frequency > motherboard?.Chipset.SupportXmp.Frequency)
            {
                slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
            }
        }

        if (motherboard?.Chipset.RamFrequency.FirstOrDefault(frequency =>
                frequency >= ram?.JedecProfile.Frequency) ==
            0)
        {
            slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
        }

        return slower;
    }
}