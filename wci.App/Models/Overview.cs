namespace wci.App.Models;

public sealed record Overview
{
    public string Hostname { get; set; } = null!;
    public string Model { get; set; } = null!;
    public string Architecture { get; set; } = null!;
    public string Platform { get; set; } = null!;
    public string FirmwareVersion { get; set; } = null!;
    public string KernelVersion { get; set; } = null!;
    public string Uptime { get; set; } = null!;

}
