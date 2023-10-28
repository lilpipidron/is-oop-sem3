using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareMotherboardAndCpu : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.Motherboard.Socket.Equals(validationModel.Cpu.Socket) is false)
        {
            return new ComponentResult.Failed("Sockets don't match");
        }

        if (validationModel.Motherboard.Bios.SupportedCpu.FirstOrDefault(component => validationModel.Cpu.Equals(component)) is null)
        {
            return new ComponentResult.Failed("BIOS does not support this Cpu");
        }

        return new ComponentResult.FullCompatible();
    }
}