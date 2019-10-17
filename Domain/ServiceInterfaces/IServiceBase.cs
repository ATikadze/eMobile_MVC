using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.ServiceInterfaces
{
    public interface IServiceBase<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> Set();
        void Save(TEntity entity);
        void Remove(TEntity entity);
        TEntity Find(int id);
        void Commit();
    }
}
