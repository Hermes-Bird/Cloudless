using Data;
using Data.Models;

namespace Services.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}