using backend.Core.Interfaces;
using backend.Data;
using backend.DTOs.Auth;
using Microsoft.EntityFrameworkCore;

namespace backend.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IJwtTokenGenerator _jwt;

        // Constructor
        public AuthService(AppDbContext context, IJwtTokenGenerator jwt)
        {
            _context = context;
            _jwt = jwt;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequest request)
        {
            // Buscar usuario por email
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == request.UserOrEmail
                || x.UserName == request.UserOrEmail
                );

            // Si el usuario no existe
            if (user == null)
                return null;

            // Verificar contraseña
            bool validPassword = BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.PasswordHash);

            // Si la contraseña es incorrecta
            if (!validPassword)
                return null;

            // Generar token JWT
            string token = _jwt.GenerateToken(user);

            // Devolver la respuesta
            return new LoginResponseDto
            {
                Token = token,
                Email = user.Email,
                Role = user.Role,
            };
        }
    }
}