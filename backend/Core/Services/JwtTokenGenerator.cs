using backend.Core.Interfaces;
using backend.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace backend.Core.Services
{
    /**
    * Servicio encargado de la generación de tokens JWT.
    * Incluye claims del usuario y configuración de seguridad (issuer, audience, key).
    */
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _config;
        public JwtTokenGenerator(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            // Clave secreta utilizada para firmar el token
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
                // Identidad del usuario dentro del token
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),

                // Email del usuario
                new Claim(ClaimTypes.Email, user.Email),

                // Rol para autorización (Admin, User, etc.)
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }


}
