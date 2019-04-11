using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using EquipmentInventory.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace EquipmentInventory.Repository
{
    static class SpecificationExecutor<T> where T : class, IBasicEntity
    {
        public static IQueryable<T> GenerateQuery(IQueryable<T> contextQueryable, Specification<T> specification )
        {
            var userQuery = contextQueryable;
            
            
            if (specification.ExpresionWhere != null)
            {
                userQuery = userQuery.Where(specification.ExpresionWhere);
            }

            if (specification.Include.Any())
            {
                userQuery = specification.Include.Aggregate(userQuery, (x, y) => x.Include(y));
            }

            if (specification.Order != null)
            {
                userQuery = userQuery.OrderBy(specification.Order);
            }
            else if(specification.OrderDesc != null)
            {
                userQuery = userQuery.OrderBy(specification.OrderDesc);
            }

            if (specification.PageActive)
            {
                userQuery = userQuery.Skip(specification.PageSkip).Take(specification.PageTake);
                specification.PageActive = false; 
            }

            return userQuery;

        } 
        
        

        
    }
}