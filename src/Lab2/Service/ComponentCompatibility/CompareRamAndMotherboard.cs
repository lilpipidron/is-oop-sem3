using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class CompareRamAndMotherboard : IComponentCompatibility
{
    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        if (validationModel.Ram.AmountBoards > validationModel.Motherboard.RamCapacity)
        {
            return new ComponentResult.Failed("Too many Ram boards");
        }

        ComponentResult slower = new ComponentResult.FullCompatible();
        if (validationModel.Ram.XmpProfile is not null && validationModel.Motherboard.Chipset.SupportXmp is null)
        {
            return new ComponentResult.Failed("Motherboard doesn't support Xmp");
        }

        if (validationModel.Ram.VersionDdr != validationModel.Motherboard.DdrStandard)
        {
            return new ComponentResult.Failed("Motherboard doesn't support this DDR version");
        }

        if (validationModel.Ram.XmpProfile is not null && validationModel.Motherboard.Chipset.SupportXmp is not null)
        {
            if (validationModel.Ram.XmpProfile.Frequency > validationModel.Motherboard.Chipset.SupportXmp.Frequency)
            {
                slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
            }
        }

        if (validationModel.Motherboard.Chipset.RamFrequency.FirstOrDefault(frequency =>
                frequency >= validationModel.Ram.JedecProfile.Frequency) ==
            0)
        {
            slower = new ComponentResult.Compatible("Ram will run at slower frequencies");
        }

        return slower;
    }
}