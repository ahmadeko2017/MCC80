using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
{
    /// <inheritdoc />
    public EmployeeRepository(BookingDbContext context) : base(context)
    {
    }
}