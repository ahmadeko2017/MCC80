using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Repositories;

public class UniversityRepository : GeneralRepository<University>, IUniversityRepository
{
    public UniversityRepository(BookingDbContext context) : base(context) { }

    #region Implementation of IUniversityRepository

    /// <inheritdoc />
    public University? GetByCode(string code)
    {
        
        return _context.Set<University>().SingleOrDefault(u => u.Code.Contains(code));
    }

    public Guid GetLastUniversityGuid()
    {
        return _context.Set<University>().LastOrDefault().Guid;
    }

    #endregion
}