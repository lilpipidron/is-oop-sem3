using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Rams;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareRamAndMotherboard<T1, T2> : IComponentCompatibility<T1, T2>
    where T1 : Collection<IRam>
    where T2 : IMotherboard
{
    public Result CheckCompability(T1 component1, T2 component2)
    {
        if (component1.Count() > component2.RamCapacity)
        {
            return new Result.Failed("Too many Ram boards");
        }

        Result slower = new Result.FullCompatible();
        foreach (IRam ram in component1)
        {
            if (ram.XmpProfile is not null && component2.Chipset.SupportXmp is null)
            {
                return new Result.Failed("Motherboard doesn't support Xmp");
            }

            if (ram.VersionDdr != component2.DdrStandard)
            {
                return new Result.Failed("Motherboard doesn't support this DDR version");
            }

            if (ram.XmpProfile is not null && component2.Chipset.SupportXmp is not null)
            {
                if (ram.XmpProfile.Frequency > component2.Chipset.SupportXmp.Frequency)
                {
                    slower = new Result.Compatible("Ram will run at slower frequencies");
                }
            }

            if (component2.Chipset.RamFrequency.FirstOrDefault(frequency => frequency >= ram.JedecProfile.Frequency) ==
                0)
            {
                slower = new Result.Compatible("Ram will run at slower frequencies");
            }
        }

        return slower;
    }
}