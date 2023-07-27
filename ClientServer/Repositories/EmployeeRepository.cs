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

    public string? GetLastNik()
    {
        return _context.Set<Employee>().OrderBy(e => e.NIK)
            .LastOrDefault()
            ?.NIK;
    }

    #region Implementation of IEmployeeRepository

    /// <inheritdoc />
    public Employee? GetByEmail(string email)
    {
        return _context.Set<Employee>().SingleOrDefault(e => e.Email.Contains(email));
    }

    public Employee? CheckEmail(string email)
    {
        return _context.Set<Employee>().FirstOrDefault(u => u.Email == email);
    }

    public Guid GetLastEmployeeGuid()
    {
        return _context.Set<Employee>().LastOrDefault().Guid;
    }

    #endregion
}