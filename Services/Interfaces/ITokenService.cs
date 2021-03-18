using Data;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}