using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    /// <inheritdoc />
    public AccountRoleRepository(BookingDbContext context) : base(context)
    {
    }

    public IEnumerable<string>? GetRoleNamesByAccountGuid(Guid guid)
    {
        var result = _context.Set<AccountRole>()
            .Where(ar => ar.AccountGuid == guid)
            .Include(ar => ar.Role)
            .Select(ar => ar.Role!.Name);

        return result;
    }
}