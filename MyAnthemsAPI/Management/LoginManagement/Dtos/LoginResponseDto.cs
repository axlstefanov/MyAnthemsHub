namespace MyAnthemsAPI.Management.LoginManagement.Dtos
{
    public record LoginResponseDto(Guid Id, string Username, string Email, string Token);
}