using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EquipmentInventory.Repository.Specification
{
    public class Specification <TEntity>
    {
        
        
      
        public Expression<Func<TEntity, bool>> Where {  get ; private set; }
        public Expression<Func<TEntity, object>> Order { get; private set; }
        public Expression<Func<TEntity, object>> OrderDescending { get; private set; }
        public List<Expression<Func<TEntity, object>>> Include { get; private set; }
        
        public bool PageActive {get; private set; }
        public int PageSkip {get; private set; }
        public int PageTake {get; private set; }
      

        private Specification()
        {
              Include = new List<Expression<Func<TEntity, object>>>();
              PageActive = false; 
        }

        public  Specification(Expression<Func<TEntity, bool>> expression) : this()
        {
            Where = expression; 
        }

        public Specification(Expression<Func<TEntity, bool>> where , Expression<Func<TEntity, object>> order = null, 
            Expression<Func<TEntity, object>> orderDescending = null, List<Expression<Func<TEntity, object>>> include = null, 
            int pageSize = 0, int pageTake = 0) : this(where) 
        {
        
            Order = order;
            OrderDescending = orderDescending;
            Include = include;
            AddPaging(pageSize,pageTake);
        }


        public  void AddInclude( Expression<Func<TEntity, object>> include)
        {
           Include.Add(include);
           
        }

        public  void  AddOrderBy(Expression<Func<TEntity, object>> expression)
        {

            Order = expression;
            
        } 
        public  void  AddOrderByDescending(Expression<Func<TEntity, object>> expression)
        {

            OrderDescending = expression; 
           

        }
        public void AddPaging(int pageSize, int page )
        {
            if (!(pageSize == 0 && page == 0))
            {
                PageActive = true; 
            }   
            
            PageSkip = pageSize * page;
            PageTake = pageSize;

        }


     
    }
}