using PBTestServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBTestServices.Services.Interfaces;

public interface IPBTestService
{
    Task<IEnumerable<OwnerDto>> GetOwnersViaDapperAsync();
    Task<IEnumerable<OwnerDto>> GetOwnersViaEFCoreAsync();
}