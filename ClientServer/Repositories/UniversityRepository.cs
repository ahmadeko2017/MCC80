using ClientServer.Contracts;
using ClientServer.Data;
using ClientServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientServer.Repositories;

public class UniversityRepository : GeneralRepository<University>, IUniversityRepository
{
    public UniversityRepository(BookingDbContext context) : base(context) { }
}