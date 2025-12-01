namespace wci.App.Models;

public sealed record Login
{
    public string? Result { get; init; }
    public string? Error { get; init; }
}
