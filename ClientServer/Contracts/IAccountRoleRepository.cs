using ClientServer.Models;

namespace ClientServer.Contracts;

public interface IAccountRoleRepository : IGeneralRepository<AccountRole>
{
    IEnumerable<string>? GetRoleNamesByAccountGuid(Guid guid);
}