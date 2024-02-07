using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareCpuAndCoolingSystem : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.CoolingSystem.Socket.FirstOrDefault(socket => validationModel.Cpu.Socket.Equals(socket)) is null)
        {
            return new ComponentResult.Failed("The cooling system does not support the CPU socket");
        }

        if (validationModel.Cpu.Tdp > validationModel.CoolingSystem.MaxTdp)
        {
            return new ComponentResult.Compatible("The store disclaims liability and warranty obligations");
        }

        return new ComponentResult.FullCompatible();
    }
}