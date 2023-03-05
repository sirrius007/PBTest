using DataAccess.Models;

namespace DataAccess.Repositories.Interfaces;

public interface IOwnerRepository
{
    Task<IEnumerable<Owner>> GetAllAsync();
}