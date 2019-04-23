using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using System.Xml.Linq;
using Autofac.Features.Scanning;
using AutoMapper;
using EquipmentInventory.Context;
using EquipmentInventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.Logging;
using Remotion.Linq.Clauses;

namespace EquipmentInventory.Repository
{
    public class GenericRepository<TEntity, T> : IGenericRepository<TEntity, T>
        where TEntity : class, IBasicEntity where T : DbContext
    {
        private readonly T _context;
        private readonly SpecificationQueryableBuilder<TEntity> _queryableBuilder;

        

        public GenericRepository(T context, SpecificationQueryableBuilder<TEntity> queryableBuilder )
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _queryableBuilder = queryableBuilder ?? throw new ArgumentNullException(nameof(queryableBuilder));
        }

        public virtual async Task<TEntity> FindByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindOneAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            return await _context.Set<TEntity>().FindAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<TEntity>().Add(entity);
            await this.SaveChangesAsync(entity);

            return entity;
        }

        public async Task Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
           

            await this.SaveChangesAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> Find(Specification<TEntity> specification)
        {
       
              return await _queryableBuilder
                .GenerateQuery(
                    _context.Set<TEntity>().AsQueryable().AsNoTracking(), 
                    specification)
                .ToListAsync();
        }

        public async Task Delete(int id)
        {
            if (id == 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var entity = FindByIdAsync(id);

            if (entity.IsCompleted)
            {
                _context.Set<TEntity>().Remove(entity.Result);
            }

            await SaveChangesAsync(entity.Result);
        }

        private async Task SaveChangesAsync(TEntity entity)
        {
            await _context.SaveChangesAsync();
        }


        
    }
    
    
    
}