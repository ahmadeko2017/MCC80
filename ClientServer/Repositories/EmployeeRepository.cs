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

    public bool IsNotExist(string value)
    {
        return _context.Set<Employee>()
            .SingleOrDefault(e => e.Email.Contains(value)
                                                   || e.PhoneNumber.Contains(value)) is null;
    }
}