using AutoMapper;
using DataAccess.Models;
using PBTestServices.DTOs;

namespace PBTestServices.Mapper;

public class OwnerProfile : Profile
{
    public OwnerProfile()
    {
        CreateMap<Owner, OwnerDto>();
    }
}