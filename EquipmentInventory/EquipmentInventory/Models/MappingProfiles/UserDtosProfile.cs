using AutoMapper;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Models.MappingProfiles
{
    public class UserDtosProfile : Profile
    {
        public UserDtosProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}