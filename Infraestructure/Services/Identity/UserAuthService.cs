using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Application.Interfaces.Identity;
using Domain.User;
using Infraestructure.Options.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Infraestructure.Services.Identity;

public class UserAuthService : IUserAuthService
{
    public string LoginAsync(UserAd user)
    {
        var handler = new JwtSecurityTokenHandler();
        var secret = Encoding.UTF8.GetBytes(IdentityOptions.ClientSecret);

        var credentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);

        var claims = new ClaimsIdentity(
            [
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name.Value),
                new Claim(ClaimTypes.Role, "user")
            ]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = credentials,
            Expires = DateTime.UtcNow.AddDays(1),
            Subject = claims
        };

        var tokenHandler = handler.CreateToken(tokenDescriptor);
        return handler.WriteToken(tokenHandler);
    }
}
