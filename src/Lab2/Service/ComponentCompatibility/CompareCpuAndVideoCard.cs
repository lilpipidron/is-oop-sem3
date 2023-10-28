using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndVideoCard : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.VideoCard is not null) return new ComponentResult.FullCompatible();
        if (validationModel.Cpu.VideoCore is null)
        {
            return new ComponentResult.Failed("System has no GPU");
        }

        return new ComponentResult.FullCompatible();
    }
}