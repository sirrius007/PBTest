using Dapper;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using static DataAccess.SharedConstants;

namespace DataAccess.Repositories;

public class OwnerDapperRepository : IOwnerRepository
{
    private readonly IConfiguration _config;

    public OwnerDapperRepository(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<Owner>> GetAllAsync()
    {
        const string SQL_GET_OWNERS = @"SELECT o.Id AS Id, o.FirstName, o.MiddleName, o.LastName, o.Birthday,
                                               r.Id, r.Name AS Name, r.Address AS Address, r.Cost AS Cost
                                        FROM Owners AS o
	                                    LEFT JOIN RealEstates AS r ON o.Id = r.OwnerId";

        var ownerMap = new Dictionary<int, Owner>();

        using (var con = new SqliteConnection(_config.GetConnectionString(ConnectionString)))
        {
            await con.QueryAsync<Owner, RealEstate, Owner>(SQL_GET_OWNERS,
                map: (owner, realEstate) =>
                {
                    if (ownerMap.TryGetValue(owner.Id, out var existingOrder))
                    {
                        owner = existingOrder;
                    }
                    else
                    {
                        owner.RealEstates = new List<RealEstate>();
                        ownerMap.Add(owner.Id, owner);

                    }

                    if (realEstate is not null)
                    {
                        realEstate.OwnerId = owner.Id;
                        owner.RealEstates?.Add(realEstate);
                    }
                    return owner;
                }
            );
        }

        return ownerMap.Values;
    }
}