using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class AccountRepository : GeneralRepository<Account>, IAccountRepository
{
    /// <inheritdoc />
    public AccountRepository(BookingDbContext context) : base(context)
    {
    }
}