using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using EquipmentInventory.Models;
using Microsoft.EntityFrameworkCore;

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
        
        public async Task<IEnumerable<Equipment>> GetEagerListEquipmentByType(TypeEquipment typeEquipment)
        {


            return await GetContextQueryable().Where(e => e.TypeEquioment == typeEquipment)
                .Include(u => u.Company)
                .Include(u => u.Model)
                .Include(u => u.Specification)
                .Include(u => u.CurrentLocalization)
                .Include(u => u.CurrentUser)
                .Include(u => u.Invoice)
                .Include(u => u.History)
                .AsNoTracking()
                .ToListAsync();
        }
        
    }

    
}