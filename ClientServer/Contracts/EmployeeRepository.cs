using ClientServer.Models;

namespace ClientServer.Contracts;

public interface IEmployeeRepository : IGeneralRepository<Employee>
{
    public bool IsNotExist(string value);
    public string? GetLastNik();
}