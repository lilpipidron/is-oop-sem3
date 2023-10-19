namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public interface IWiFiBuilder
{
    IWiFiBuilder WithName(string name);

    IWiFiBuilder WithWiFiVersion(int wifiVersion);

    IWiFiBuilder WithBluetooth(bool bluetooth);

    IWiFiBuilder WithVersionPciE(string versionPciE);

    IWiFiBuilder WithPowerConsumption(int powerConsumption);

    WiFiAdapter Build();
}