using ClientServer.Models;

namespace ClientServer.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    bool IsNotExist(string value);
    string? GetLastNik();
    Employee? GetByEmail(string email);
}