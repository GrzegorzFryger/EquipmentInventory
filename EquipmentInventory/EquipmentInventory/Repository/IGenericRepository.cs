using System.Collections.Generic;
using System.Threading.Tasks;
using EquipmentInventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Repository
{
    public interface  IGenericRepository<TEntity,T>  where TEntity : class, IBasicEntity  where T :  DbContext
    {
        Task <TEntity> FindByIdAsync(int id);
        Task<TEntity> FindOneAsync(TEntity entity);
        Task <IEnumerable<TEntity>> FindAllAsync();
        Task<TEntity> Add(TEntity entity);
        Task Update(TEntity entity);
        
        Task Delete(int id);
        Task Delete(TEntity entity);
        Task<IReadOnlyCollection<TEntity>> Find(Specification<TEntity> specification);



    }

    
}