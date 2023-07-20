using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class RoleRepository : GeneralRepository<Role>, IRoleRepository
{
    /// <inheritdoc />
    public RoleRepository(BookingDbContext context) : base(context)
    {
    }
}