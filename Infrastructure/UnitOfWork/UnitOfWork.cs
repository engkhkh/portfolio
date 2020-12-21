using System;
using System.Collections.Generic;
using System.Text;
using Core.Interfaces;
using Infrastructure.Repository;
namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<t> : IunitOfWork<t> where t : class
    {
        public DataContext Context { get; }
        private Core.Interfaces.IGenericRepository<t> _entity;
        public UnitOfWork(DataContext context)
      
        {
            Context = context;
        }

       

        

        public Core.Interfaces.IGenericRepository<t> Entity
        {
            get
            {
                return _entity ?? (_entity = new Infrastructure.Repository.GenericRepository<t>(Context));
            }
        
        
        }

        public void save()
        {
            Context.SaveChanges();
        }
    }
}
