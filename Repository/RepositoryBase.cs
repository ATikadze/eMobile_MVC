using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
    using Domain.RepositoryInterfaces;
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        protected eMobileDbContext _context;
        public RepositoryBase(eMobileDbContext context)
        {
            _context = context;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void Save(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IEnumerable<TEntity> Set()
        {
            return _context.Set<TEntity>();
        }
    }
}
