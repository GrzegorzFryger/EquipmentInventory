using AutoMapper;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Models.MappingProfiles
{
    public class CompanyDtoProfile : Profile
    {
        public CompanyDtoProfile()
        {
            CreateMap<Company, CompanyDto>(); 
        }
    }
}