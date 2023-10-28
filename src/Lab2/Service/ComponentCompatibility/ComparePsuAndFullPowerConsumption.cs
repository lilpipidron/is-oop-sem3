using Itmo.ObjectOrientedProgramming.Lab2.Entities.Pcs;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Results;

namespace Itmo.ObjectOrientedProgramming.Lab2.Service.ComponentCompatibility;

public class ComparePsuAndFullPowerConsumption : IComponentCompatibility
{
    private const double MaxEffectivePercent = 0.8;

    public ComponentResult CheckCompability(PcBuilder.PcValidationModel validationModel)
    {
        int allPowerConsumption = validationModel.Cpu.PowerConsumption + validationModel.Ram.PowerConsumption;
        if (validationModel.VideoCard is not null)
        {
            allPowerConsumption += validationModel.VideoCard.PowerConsumption;
        }

        if (validationModel.Hdd is not null)
        {
            allPowerConsumption += validationModel.Hdd.PowerConsumption;
        }

        if (validationModel.Ssd is not null)
        {
            allPowerConsumption += validationModel.Ssd.PowerConsumption;
        }

        if (validationModel.Motherboard.WiFiAdapter is not null)
        {
            allPowerConsumption += validationModel.Motherboard.WiFiAdapter.PowerConsumption;
        }

        if (allPowerConsumption > validationModel.Psu.PeakLoad * MaxEffectivePercent)
        {
            return new ComponentResult.Compatible("Failure to comply with recommended Psu power delivery capacities");
        }

        return new ComponentResult.FullCompatible();
    }
}