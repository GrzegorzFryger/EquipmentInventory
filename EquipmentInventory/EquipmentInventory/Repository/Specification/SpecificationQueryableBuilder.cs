using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using EquipmentInventory.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Repository
{
     public class SpecificationQueryableBuilder<T> where T : class, IBasicEntity
    {
        public  IQueryable<T> GenerateQuery(IQueryable<T> contextQueryable, Specification<T> specification )
        {
            
            
            var userQuery = contextQueryable;
            
            if (specification.Where != null)
            {
                userQuery = userQuery.Where(specification.Where);
            }

            if (specification.Include.Any())
            {
                userQuery = specification.Include
                    .Aggregate(userQuery, (x, y) => x.Include(y));
            }

            if (specification.Order != null)
            {
                userQuery = userQuery.OrderBy(specification.Order);
            }
            else if(specification.OrderDescending != null)
            {
                userQuery = userQuery
                    .OrderBy(specification.OrderDescending);
            }

            if (specification.PageActive)
            {
                userQuery = userQuery
                    .Skip(specification.PageSkip)
                    .Take(specification.PageTake);
                
            }

            return userQuery;

        } 
        
        

        
    }
}