using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;

namespace ClientServer.Repositories;

public class EducationRepository : GeneralRepository<Education>, IEducationRepository
{
    /// <inheritdoc />
    public EducationRepository(BookingDbContext context) : base(context)
    {
    }
}