using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.PcCases;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndMotherboard : IComponentCompatibility
{
    private readonly IPcCase _pcCase;
    private readonly IMotherboard _motherboard;

    public ComparePcCaseAndMotherboard(IPcCase pcCase, IMotherboard motherboard)
    {
        _pcCase = pcCase;
        _motherboard = motherboard;
    }

    public ComponentResult CheckCompability()
    {
        if (_pcCase.MotherBoardForms.FirstOrDefault(form => form == _motherboard.MotherBoardFormFactor) is null)
        {
            return new ComponentResult.Failed("The case does not support this form factor");
        }

        return new ComponentResult.FullCompatible();
    }
}