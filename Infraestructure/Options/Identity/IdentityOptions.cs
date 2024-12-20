namespace Infraestructure.Options.Identity;

public class IdentityOptions
{
    public static string Issuer { get; set; } = string.Empty;
    public static string Audience { get; set; } = string.Empty;
    public static string PublicKey { get; set; } = string.Empty;
    public static string ClientSecret { get; set; } = string.Empty;
    public static string Section => "Identity";
}