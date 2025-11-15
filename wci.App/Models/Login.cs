namespace wci.App.Models;

public sealed record Login
{
    public string? Token { get; init; }
    public string? Error { get; init; }
}
