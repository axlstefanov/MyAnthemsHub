using MyAnthemsAPI.Models.UserManagement;

namespace MyAnthemsAPI.Services.Authentication
{
    public interface IJwtTokenService
    {
        string GenerateToken(User user);
    }
}