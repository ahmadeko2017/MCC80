using System.Security.Claims;

namespace ClientServer.Contracts;

public interface ITokenHandler
{
    string? GenerateToken(IEnumerable<Claim> claims);
}