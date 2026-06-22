using backend.DTOs.Auth;
namespace backend.Core.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequest request);
    }
}
