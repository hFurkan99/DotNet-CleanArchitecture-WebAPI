namespace App.Domain.Options;

public class ConnectionStringOption
{
    public const string Key = "ConnectionStrings";
    public string DefaultConnection { get; set; } = default!;
}
