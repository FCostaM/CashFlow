using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlow.Infrastructure.Security;

/// <summary>
/// Generates JWT tokens for authenticated users.
/// </summary>
internal class JwtTokenGenerator : ITokenGenerator
{
    /// <summary>
    /// The expiration time of the token in seconds.
    /// </summary>
    private readonly uint _expirationTime;

    /// <summary>
    /// The key used to sign the token.
    /// </summary>
    private readonly string _singnigKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="JwtTokenGenerator"/> class with the specified expiration time and signing key.
    /// </summary>
    /// <param name="expirationTime">The expiration time in seconds.</param>
    /// <param name="signingKey">The key used to sign the token.</param>
    public JwtTokenGenerator(uint expirationTime, string singnigKey)
    {
        _expirationTime = expirationTime;
        _singnigKey = singnigKey;
    }

    /// <summary>
    /// Generates a JWT token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the token is being generated.</param>
    /// <returns>A JWT token as a string.</returns>
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim("Name", user.Name),
            new Claim("SId", user.UserIdentifier.ToString())
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddSeconds(_expirationTime),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHanlder = new JwtSecurityTokenHandler();
        var securityToken = tokenHanlder.CreateToken(tokenDescriptor);

        return tokenHanlder.WriteToken(securityToken);
    }

    /// <summary>
    /// Creates a symmetric security key from the signing key.
    /// </summary>
    /// <returns>A symmetric security key.</returns>
    private SymmetricSecurityKey SecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_singnigKey));
    }
}
