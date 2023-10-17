namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiAdapter : IWiFiAdapter
{
    private readonly int _wifiVersion;
    private readonly bool _bluetooth;
    private readonly string _versionPciE;
    private readonly int _powerConsumption;

    public WiFiAdapter(int wifiVersion, bool bluetooth, string versionPciE, int powerConsumption)
    {
        _wifiVersion = wifiVersion;
        _bluetooth = bluetooth;
        _versionPciE = versionPciE;
        _powerConsumption = powerConsumption;
    }

    public IWiFiBuilder Director(IWiFiBuilder builder)
    {
        builder
            .WithWiFiVersion(_wifiVersion)
            .WithBluetooth(_bluetooth)
            .WithVersionPciE(_versionPciE)
            .WithPowerConsumption(_powerConsumption);

        return builder;
    }
}