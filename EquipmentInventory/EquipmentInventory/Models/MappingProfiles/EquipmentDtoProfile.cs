using AutoMapper;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Models.MappingProfiles
{
    public class EquipmentDtoProfile : Profile
    {
        public EquipmentDtoProfile()
        {
            CreateMap<Equipment, EquipmentDto>(); 
        }
        
        
    }
}