using Itmo.ObjectOrientedProgramming.Lab2.Entities.Bioses;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Chipsets;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;
using Itmo.ObjectOrientedProgramming.Lab2.Model.MotherboardFormFactors;
using Itmo.ObjectOrientedProgramming.Lab2.Model.Sockets;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Motherboards;

public interface IMotherboardBuilder
{
    IMotherboardBuilder WithSocket(PcSocket socket);

    IMotherboardBuilder WithPciE(int pciE);

    IMotherboardBuilder WithSata(int sata);

    IMotherboardBuilder WithChipset(IChipset chipset);

    IMotherboardBuilder WithDdrStandard(int ddrStandard);

    IMotherboardBuilder WithRamCapacity(int ramCapacity);

    IMotherboardBuilder WithMotherBoardFormFactor(MotherBoardFormFactor motherBoardFormFactor);

    IMotherboardBuilder WithBios(IBios bios);

    IMotherboardBuilder WithWiFiAdapter(IWiFiAdapter wiFiAdapter);

    IMotherboard Build();
}