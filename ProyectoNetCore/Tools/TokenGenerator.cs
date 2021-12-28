using Microsoft.IdentityModel.Tokens;
using ProyectoNetCore.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoNetCore.Tools
{
    public class TokenGenerator
    {
        public static string CreateToken(User obj, JWTConfig jwtConfig)
        {
            var expires = DateTime.UtcNow.AddSeconds(jwtConfig.Expires);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtConfig.Issuer,
                Audience = jwtConfig.Audience, // Generar al cliente un código hash
                Expires = expires,
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.NameIdentifier, obj.Username),
                    new Claim(ClaimTypes.Name, obj.Name),
                    new Claim(ClaimTypes.Email, obj.Email),
                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}