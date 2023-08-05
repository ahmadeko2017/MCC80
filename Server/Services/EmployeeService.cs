using ClientServer.Contracts;
using ClientServer.DTOs.Employees;
using ClientServer.Models;
using ClientServer.Repositories;
using ClientServer.Utilities.Handlers;

namespace ClientServer.Services;

public class EmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEducationRepository _educationRepository;
    private readonly IUniversityRepository _universityRepository;

    public EmployeeService(IEmployeeRepository employeeRepository, IEducationRepository educationRepository, IUniversityRepository universityRepository)
    {
        _employeeRepository = employeeRepository;
        _educationRepository = educationRepository;
        _universityRepository = universityRepository;
    }
    
    public IEnumerable<EmployeeDto> GetAll()
    {
        var employees = _employeeRepository.GetAll();
        if (!employees.Any())
        {
            return Enumerable.Empty<EmployeeDto>();
        }

        var employeesDtos = new List<EmployeeDto>();
        foreach (var employee in employees)
        {
            employeesDtos.Add((EmployeeDto)employee);
        }

        return employeesDtos;
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
        var lastNik = _employeeRepository.GetLastNik();
        Employee emp = newEmployeeDto;
        emp.NIK = GenerateHandler.NIK(lastNik);
        
        var employee = _employeeRepository.Create(emp);
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

    public IEnumerable<EmployeeDetailDto> GetAllEmployeeDetail()
    {
        var result = from employee in _employeeRepository.GetAll()
            join education in _educationRepository.GetAll() on employee.Guid equals education.Guid
            join university in _universityRepository.GetAll() on education.UniversityGuid equals
                university.Guid
            select new EmployeeDetailDto {
                EmployeeGuid = employee.Guid,
                NIK = employee.NIK,
                FullName = employee.FirstName + " " + employee.LastName,
                BirthDate = employee.BirthDate,
                Gender = employee.Gender,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Major = education.Major,
                Degree = education.Degree,
                GPA = education.GPA,
                UniversityName = university.Name
            };

        return result;
    }

    public EmployeeDetailDto? GetEmployeeDetailByGuid(Guid guid)
    {
        var employee = _employeeRepository.GetByGuid(guid);
        if (employee is null)
        {
            return null;
        }

        var education = _educationRepository.GetByGuid(employee.Guid);
        var university = _universityRepository.GetByGuid(education.UniversityGuid);
        
        return new EmployeeDetailDto()
        {
            EmployeeGuid = employee.Guid,
            NIK = employee.NIK,
            FullName = employee.FirstName + " " + employee.LastName,
            BirthDate = employee.BirthDate,
            Gender = employee.Gender,
            HiringDate = employee.HiringDate,
            Email = employee.Email,
            PhoneNumber = employee.PhoneNumber,
            Major = education.Major,
            Degree = education.Degree,
            GPA = education.GPA,
            UniversityName = university.Name
        };
    }
}