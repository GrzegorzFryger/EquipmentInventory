using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;

namespace EquipmentInventory.Repository
{
    public class EquipmentRepository : GenericRepository<Equipment, InventoryEquipmentContext>
    {
        public EquipmentRepository(InventoryEquipmentContext context, 
            SpecificationQueryableBuilder<Equipment> queryableBuilder) : base(context, queryableBuilder)
        {
            
        }

        public int GetCountEquipment(Expression<Func<Equipment, bool>> where)
        {
            return  GetContextQueryable().Where(where).Count();
        }
        
    }

    
}