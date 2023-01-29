using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTO;
using Application.Security;
using Core.Entities;
using Core.Shared;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;

internal sealed class Authenticator : IAuthenticator
{
    private readonly string _audience;
    private readonly IClock _clock;
    private readonly TimeSpan _expiry;
    private readonly string _issuer;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly SigningCredentials _signingCredentials;

    public Authenticator(IOptions<AuthOptions> options, IClock clock)
    {
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        _clock = clock;
        _issuer = options.Value.Issuer;
        _audience = options.Value.Audience;
        _expiry = options.Value.Expiry ?? TimeSpan.FromHours(1);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SigningKey));
        _signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    }

    public JwtDto CreateToken(User user, string role)
    {
        var now = _clock.Current();
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
            new(ClaimTypes.Role, role)
        };

        var expires = now.Add(_expiry);
        var jwt = new JwtSecurityToken(_issuer, _audience, claims, now, expires, _signingCredentials);
        var token = _jwtSecurityTokenHandler.WriteToken(jwt);

        return new JwtDto
        {
            Id = user.Id,
            Email = user.Email,
            Jwt = token
        };
    }
}