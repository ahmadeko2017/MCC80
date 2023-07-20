using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class AccountRoleRepository : GeneralRepository<AccountRole>, IAccountRoleRepository
{
    /// <inheritdoc />
    public AccountRoleRepository(BookingDbContext context) : base(context)
    {
    }
}