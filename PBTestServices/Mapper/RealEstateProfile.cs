using AutoMapper;
using DataAccess.Models;
using PBTestServices.DTOs;

namespace PBTestServices.Mapper
{
    public class RealEstateProfile : Profile
    {
        public RealEstateProfile()
        {
            CreateMap<RealEstate, RealEstateDto>();
        }
    }
}
