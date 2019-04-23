using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using EquipmentInventory.Repository.Specification;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EquipmentInventory.Repository
{
    public  class SpecificationBuilder<T>
    {
        private Expression<Func<T, bool>> _where;
        private Expression<Func<T, object>> _order;
        private Expression<Func<T, object>> _orderDescending;
        private List<Expression<Func<T, object>>> _include;

        private int _pageSize;
        private int _pageTake ;

      

        public SpecificationBuilder()
        {
            _include = new List<Expression<Func<T, object>>>();
        }

        public SpecificationBuilder<T> Where(Expression<Func<T, bool>> where)
        {
             _where = where;
             return this;
        }

        public SpecificationBuilder<T> Include(Expression<Func<T, object>> include)
        {
             _include.Add(include);
             return this;
        }
        
        public SpecificationBuilder<T> OrderBy(Expression<Func<T, object>> orderBy, bool descending )
        {
            if (descending == true)
            {
                _orderDescending = orderBy;
            }
            else
            {
                _order = orderBy;
            }
            return this;
        }
        
        public void Paging(int pageSize, int page )
        {
            _pageSize = pageSize;
            _pageTake = page;

        }
        
        
        public static implicit operator Specification<T>(SpecificationBuilder<T> builder)
        {
            if (builder._where != null)
            {
                return new Specification<T>(
                    builder._where,
                    builder._order,
                    builder._orderDescending,
                    builder._include,
                    builder._pageSize,
                    builder._pageTake
                    
                );
            }
           
            throw new ArgumentException("Expression should starts with where case ");
        }
    }
}