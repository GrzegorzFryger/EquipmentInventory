using EquipmentInventory.Context;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Repository
{
    public interface IUserRepository : IGenericRepository<User,InventoryEquipmentContext>
    {
        
    }
}