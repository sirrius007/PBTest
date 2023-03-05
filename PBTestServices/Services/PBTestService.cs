using AutoMapper;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using PBTestServices.DTOs;
using PBTestServices.Services.Interfaces;

namespace PBTestServices.Services;

public class PBTestService : IPBTestService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;
    public PBTestService(
        IServiceProvider serviceProvider,
        IMapper mapper)
    {
        _serviceProvider = serviceProvider;
        _mapper = mapper;
    }

    public async Task<IEnumerable<OwnerDto>> GetOwnersViaDapperAsync()
    {
        var repositories = _serviceProvider.GetServices<IOwnerRepository>();
        var ownerRepository = repositories
            .FirstOrDefault(x => x.GetType() == typeof(OwnerDapperRepository))
            ?? throw new ArgumentNullException(nameof(OwnerDapperRepository));
        var owners = await ownerRepository.GetAllAsync();
        var ownersDtos = _mapper.Map<IEnumerable<OwnerDto>>(owners);
        return ownersDtos;
    }

    public async Task<IEnumerable<OwnerDto>> GetOwnersViaEFCoreAsync()
    {
        var repositories = _serviceProvider.GetServices<IOwnerRepository>();
        var ownerRepository = repositories
            .FirstOrDefault(x => x.GetType() == typeof(OwnerEFCoreRepository))
            ?? throw new ArgumentNullException(nameof(OwnerEFCoreRepository));
        var owners = await ownerRepository.GetAllAsync();
        var ownersDtos = _mapper.Map<IEnumerable<OwnerDto>>(owners);
        return ownersDtos;
    }
}