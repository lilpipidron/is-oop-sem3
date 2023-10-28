using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndRam : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.Ram.XmpProfile is not null)
        {
            if (validationModel.Ram.XmpProfile.Frequency != validationModel.Cpu.CoreFrequency)
            {
                return new ComponentResult.Failed("The processor does not support these frequencies");
            }
        }

        if (validationModel.Ram.JedecProfile.Frequency == validationModel.Cpu.CoreFrequency)
        {
            return new ComponentResult.Failed("The processor does not support these frequencies");
        }

        return new ComponentResult.FullCompatible();
    }
}