using Itmo.ObjectOrientedProgramming.Lab2.Entities.Cpus;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.VideoCards;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndVideoCard : IComponentCompatibility
{
    private readonly ICpu _cpu;
    private readonly IVideoCard? _videoCard;

    public CompareCpuAndVideoCard(ICpu cpu, IVideoCard? videoCard)
    {
        _cpu = cpu;
        _videoCard = videoCard;
    }

    public ComponentResult CheckCompability()
    {
        if (_videoCard is not null) return new ComponentResult.FullCompatible();
        if (_cpu.VideoCore is null)
        {
            return new ComponentResult.Failed("System has no GPU");
        }

        return new ComponentResult.FullCompatible();
    }
}