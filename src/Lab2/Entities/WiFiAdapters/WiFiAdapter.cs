namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapters;

public class WiFiAdapter : IWiFiAdapter
{
    internal WiFiAdapter(int wifiVersion, bool bluetooth, string versionPciE, int powerConsumption)
    {
        WifiVersion = wifiVersion;
        Bluetooth = bluetooth;
        VersionPciE = versionPciE;
        PowerConsumption = powerConsumption;
    }

    public int WifiVersion { get; }
    public bool Bluetooth { get; }
    public string VersionPciE { get; }
    public int PowerConsumption { get; }

    public IWiFiBuilder Director(IWiFiBuilder builder)
    {
        builder
            .WithWiFiVersion(WifiVersion)
            .WithBluetooth(Bluetooth)
            .WithVersionPciE(VersionPciE)
            .WithPowerConsumption(PowerConsumption);

        return builder;
    }
}