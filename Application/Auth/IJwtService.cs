using Domain.Entities;

namespace Application.Auth
{
    public interface IJwtService
    {
        string GenerateToken (User user);
    }
}
