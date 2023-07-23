using ClientServer.DTOs.Employees;
using ClientServer.DTOs.Roles;
using ClientServer.Models;
using ClientServer.Repositories;

namespace ClientServer.Services;

public class EmployeeService
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeeService(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public IEnumerable<EmployeeDto> GetAll()
    {
        var roles = _employeeRepository.GetAll();
        if (!roles.Any())
        {
            return Enumerable.Empty<EmployeeDto>();
        }

        var employees = new List<EmployeeDto>();
        foreach (var employee in employees)
        {
            employees.Add((EmployeeDto)employee);
        }

        return employees;
    }

    public EmployeeDto? GetByGuid(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        return (EmployeeDto)employee;
    }

    public NewEmployeeDto? Create(NewEmployeeDto newEmployeeDto)
    {
        var employee = _employeeRepository.Create(newEmployeeDto);
        if (employee is null)
        {
            return null;
        }

        return (NewEmployeeDto)employee;
    }

    public int Update(EmployeeDto employeeDto)
    {
        var role = _employeeRepository.GetByGuid(employeeDto.Guid);
        if (role is null)
        {
            return -1;
        }

        Employee toUpdate = employeeDto;
        toUpdate.CreatedDate = role.CreatedDate;
        var result = _employeeRepository.Update(toUpdate);

        return result ? 1 : 0;
    }

    public int Delete(Guid guid)
    {
        var role = _employeeRepository.GetByGuid(guid);
        if (role is null)
        {
            return -1;
        }

        var result = _employeeRepository.Delete(role);
        return result ? 1 : 0;
    }
}