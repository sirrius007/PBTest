using DataAccess.Data;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class OwnerEFCoreRepository : IOwnerRepository
{
    private readonly PBTestContext _db;

    public OwnerEFCoreRepository(PBTestContext db) => _db = db;

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        return await _db.Owners.Include(o => o.RealEstates).AsNoTracking().ToListAsync();
    }
}