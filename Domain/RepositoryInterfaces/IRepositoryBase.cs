using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        IEnumerable<TEntity> Set();
        void Save(TEntity entity);
        void Remove(TEntity entity);
    }
}
