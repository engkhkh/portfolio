using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IGenericRepository<t> where t:class
    {
        IEnumerable<t> GetAll();
        t getbyid(object id);
        void insert(t entity);
        void update(t entity);
        void delete(object id);

    }
}
