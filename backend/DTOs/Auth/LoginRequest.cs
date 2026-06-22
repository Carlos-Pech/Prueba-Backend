namespace backend.DTOs.Auth
{
    public class LoginRequest
    {
        public string UserOrEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
