using System;
using System.Threading.Tasks;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Repository
{
    public class UserRepository : GenericRepository<User,InventoryEquipmentContext>, IUserRepository
    {
        public UserRepository(InventoryEquipmentContext context) : base(context)
        {
        }

       
    }
}