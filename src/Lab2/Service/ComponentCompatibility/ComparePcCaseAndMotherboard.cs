using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePcCaseAndMotherboard : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.PcCase.MotherBoardForms.FirstOrDefault(form => form == validationModel.Motherboard.MotherBoardFormFactor) is null)
        {
            return new ComponentResult.Failed("The case does not support this form factor");
        }

        return new ComponentResult.FullCompatible();
    }
}