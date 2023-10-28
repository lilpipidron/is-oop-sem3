using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndVideoCard : IComponentCompatibility
{
    public ComponentResult CheckCompability(IReadOnlyCollection<IPcComponent?> pcComponents)
    {
        var cpu = pcComponents.FirstOrDefault(component => component is ICpu) as ICpu;
        var videoCard = pcComponents.FirstOrDefault(component => component is IVideoCard) as IVideoCard;
        if (videoCard is not null) return new ComponentResult.FullCompatible();
        if (cpu?.VideoCore is null)
        {
            return new ComponentResult.Failed("System has no GPU");
        }

        return new ComponentResult.FullCompatible();
    }
}