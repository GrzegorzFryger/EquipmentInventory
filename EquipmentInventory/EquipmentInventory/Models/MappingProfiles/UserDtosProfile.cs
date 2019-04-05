using AutoMapper;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Models
{
    public class UserDtosProfile : Profile
    {
        public UserDtosProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}