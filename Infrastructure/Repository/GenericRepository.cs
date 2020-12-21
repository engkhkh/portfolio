using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<t> : Core.Interfaces.IGenericRepository<t> where t : class

    {
        public DataContext Context { get; }
        private DbSet<t> table = null;

        public GenericRepository(DataContext context)
        {
            this.Context = context;
            table = Context.Set<t>();
        }

       

        //

        public void delete(object id)
        {
            t existing = getbyid(id);
            table.Remove(existing);
        }

        public IEnumerable<t> GetAll()
        {
            return table.ToList();
        }

        public t getbyid(object id)
        {
            return table.Find(id);
        }

        public void insert(t entity)
        {
            table.Add(entity);
        }

        public void update(t entity)
        {
            table.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
