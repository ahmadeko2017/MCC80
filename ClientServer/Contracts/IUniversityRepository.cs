using ClientServer.Models;

namespace ClientServer.Contracts;

public interface IUniversityRepository : IGeneralRepository<University>
{
    University? GetByCode(string code);
    Guid GetLastUniversityGuid();
}