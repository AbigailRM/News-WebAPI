using Microsoft.IdentityModel.Tokens;
using News_WebAPI.Models;
using System;

namespace News_WebAPI
{
    public interface ITokenProvider
    {
        string AToken(User user, DateTime tokenExpiration);
        TokenValidationParameters GetTokenValidation();
    }
}