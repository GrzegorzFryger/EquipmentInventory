using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;
using EquipmentInventory.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentInventory.Repository
{
    public class Specification <TEntity>
    {

       
        
        public Expression<Func<TEntity, bool>> ExpresionWhere {  get ; }
        public List<Expression<Func<TEntity, object>>> Include { get; }
        public Expression<Func<TEntity, object>> Order { get; private set; }
        public Expression<Func<TEntity, object>> OrderDesc { get; private set; }
        public int PageTake { get; private set; }
        public int PageSkip { get; private set; } 
        public bool PageActive  { get;  set; }

        private Specification()
        {
            PageActive = false;
            Include = new List<Expression<Func<TEntity, object>>>();
        }

        public Specification(Expression<Func<TEntity, bool>> expression) : this()
        {
            ExpresionWhere = expression; 
        }


        public virtual Specification<TEntity> AddInclude( Expression<Func<TEntity, object>> include)
        {
            Include.Add(include);

            return this;
        }

        public virtual Specification<TEntity>  AddOrderBy(Expression<Func<TEntity, object>> expression)
        {

            Order = expression;

            return this;
        } 
        public virtual Specification<TEntity>  AddOrderByDescending(Expression<Func<TEntity, object>> expression)
        {

            OrderDesc = expression;

            return this;
        }
        public Specification<TEntity>  AddPaging(int pageSize, int page )
        {
            PageActive = true; 
            PageSkip = pageSize * page;
            PageTake = pageSize;

            return this;
        }

        
        
       

    }
}