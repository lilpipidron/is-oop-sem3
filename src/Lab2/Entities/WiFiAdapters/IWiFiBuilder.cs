namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public interface IWiFiBuilder
{
    IWiFiBuilder WithWiFiVersion(int wifiVersion);

    IWiFiBuilder WithBluetooth(bool bluetooth);

    IWiFiBuilder WithVersionPciE(string versionPciE);

    IWiFiBuilder WithPowerConsumption(int powerConsumption);

    WiFiAdapter Build();
}