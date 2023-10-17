using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.WiFiAdapter;

public class WiFiBuilder : IWiFiBuilder
{
    private int? _wifiVersion;
    private bool? _bluetooth;
    private string? _versionPciE;
    private int? _powerConsumption;

    public IWiFiBuilder WithWiFiVersion(int wifiVersion)
    {
        _wifiVersion = wifiVersion;
        return this;
    }

    public IWiFiBuilder WithBluetooth(bool bluetooth)
    {
        _bluetooth = bluetooth;
        return this;
    }

    public IWiFiBuilder WithVersionPciE(string versionPciE)
    {
        _versionPciE = versionPciE;
        return this;
    }

    public IWiFiBuilder WithPowerConsumption(int powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(
            _wifiVersion ?? throw new ArgumentNullException(nameof(_wifiVersion)),
            _bluetooth ?? throw new ArgumentNullException(nameof(_bluetooth)),
            _versionPciE ?? throw new ArgumentNullException(nameof(_versionPciE)),
            _powerConsumption ?? throw new ArgumentNullException(nameof(_powerConsumption)));
    }
}