using Microsoft.IdentityModel.Tokens;
using News_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace News_WebAPI
{
    public class TokenProvider : ITokenProvider
    {
        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;
        public string _shaAlgorithm { get; }

        private readonly SymmetricSecurityKey _signingKey;

        public TokenProvider(string issuer, string audience, string secretKey)
        {
            _secretKey = secretKey;
            _issuer = issuer;
            _audience = audience;
            _shaAlgorithm = SecurityAlgorithms.HmacSha256Signature;
            _signingKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        }

        public string AToken(User user, DateTime tokenExpiration)
        {
            JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Name));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            SecurityToken securityToken = securityTokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = _audience,
                SigningCredentials = new SigningCredentials(_signingKey, _shaAlgorithm),
                Expires = tokenExpiration.ToUniversalTime(),
                Subject = claimsIdentity
            });

            return securityTokenHandler.WriteToken(securityToken);
        }

        public TokenValidationParameters GetTokenValidation()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _signingKey,
                ValidIssuer = _issuer,
                ValidAudience = _audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }
    }
}
