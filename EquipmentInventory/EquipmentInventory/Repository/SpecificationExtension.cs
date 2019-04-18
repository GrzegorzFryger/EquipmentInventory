using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Remotion.Linq.Clauses;

namespace EquipmentInventory.Repository
{
    public static class SpecificationExtension
    {

        public static Expression<Func<T, bool>> Or<T>( Expression<Func<T, bool>> left,  Expression<Func<T, bool>> right)
            where T : class
        {
            var parameter = Expression.Parameter(typeof(T),typeof(T).Name);
            
            return  Expression.Lambda<Func<T, bool>>(
                Expression.Or(Expression.Invoke(right, parameter),
                    Expression.Invoke(left, parameter) ),
                parameter);
        }
        
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,  Expression<Func<T, bool>> right)
            where T : class
        {
            var parameter = Expression.Parameter(typeof(T),typeof(T).Name);
            
            return  Expression.Lambda<Func<T, bool>>(
                Expression.And(Expression.Invoke(right, parameter),
                    Expression.Invoke(left, parameter) ),
                parameter);
        }


    
        
        
    }
}